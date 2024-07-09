using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour, IAttackable, IDamagable
{
    public EnemyStatus status;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigid;

    private Vector3 startPos; // 시작 지점

    // 플레이어 추격 관련
    private bool chase = false;
    private float trackingTime = 0.0f;
    private Vector3 direction; // 추격 방향
    private Vector3 leftDirection; // 왼쪽 추격 방향
    private Vector3 rightDirection; // 오른쪽 추격 방향
    private Vector3 leftRot = new Vector3(0, 0, 45f);
    private Vector3 rightRot = new Vector3(0, 0, -45f);
    private Vector3 leftTurnRot = new Vector3(0, 0, 65f);
    private Vector3 rightTurnRot = new Vector3(0, 0, -65f);

    private Vector2 size = new Vector2(2f, 2);

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        // 타겟 위치 설정
        // 싱글톤 또는 Find로 플레이어 위치 검색
        target = GameObject.Find("Player").transform;
    }

    // OnDrawGizmos()는 Scene 창에서 눈으로 확인하기 위함
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    protected void OnEnable()
    {
        if (status.monsterType != MonsterType.Boss)
        {
            StartCoroutine(RayPlayer());
            startPos = transform.position;
            StartCoroutine(ApplyDamage(5));
        }
    }

    protected virtual void FixedUpdate()
    {
        if (trackingTime > 0)
        {
            trackingTime -= Time.fixedDeltaTime;
        }
        else
        {
            chase = false;
        }
    }

    private void Movement(Vector3 pos)
    {
        float distance = pos.magnitude;
        if (distance < status.attackRange && chase)
        {
            TargetMove(Vector2.zero);
            Rotate(Vector2.zero);
        }
        else
        {
            pos.Normalize();
            TargetMove(pos);
            Rotate(pos);
        }
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        spriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    protected void TargetMove(Vector2 direction)
    {
        rigid.velocity = direction * status.moveSpeed;
    }

    protected void EnemyDie()
    {
        Managers.Pool.Push(gameObject);
    }

    public bool Attack(IDamagable target, float power, int numberOfAttacks = 0)
    {
        if (target == null) return false;

        StartCoroutine(target.ApplyDamage(power));

        return true;
    }

    public IEnumerator ApplyDamage(float dmg)
    {
        if (status.health < 0)
        {
            EnemyDie();
        }
        else
        {
            status.health -= (int)dmg;
            chase = true;
            trackingTime = 10;
        }
        
        yield return null;
    }

    // Ray로 플레이어
    private IEnumerator RayPlayer()
    {
        while (true)
        {
            if (chase)
            {
                direction = target.position - transform.position;
            }
            else
            {
                direction = startPos - transform.position;
            }
            leftDirection = Quaternion.Euler(leftRot) * direction;
            rightDirection = Quaternion.Euler(rightRot) * direction;

            RaycastHit2D hitDirection = Physics2D.Raycast(transform.position, direction, circleCollider2D.radius, LayerMask.GetMask("Wall"));
            Debug.DrawRay(transform.position, direction.normalized * circleCollider2D.radius, Color.red, 0.1f);
            Debug.DrawRay(transform.position, leftDirection.normalized * circleCollider2D.radius, Color.blue, 0.1f);
            Debug.DrawRay(transform.position, rightDirection.normalized * circleCollider2D.radius, Color.blue, 0.1f);
            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, LayerMask.GetMask("Wall"));
            if (hitDirection.collider != null || hit?.gameObject != null)
            {
                RaycastHit2D hitLeftDir = Physics2D.Raycast(transform.position, leftDirection, circleCollider2D.radius, LayerMask.GetMask("Wall"));
                RaycastHit2D hitRightDir = Physics2D.Raycast(transform.position, rightDirection, circleCollider2D.radius, LayerMask.GetMask("Wall"));
                if (hitLeftDir.collider == null)
                {
                    Movement(Quaternion.Euler(leftTurnRot) * direction);
                }
                else if (hitRightDir.collider == null)
                {
                    Movement(Quaternion.Euler(rightTurnRot) * direction);
                }
            }
            else
            {
                Movement(direction);
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!chase)
            {
                trackingTime = 10;
                chase = true;
            }
        }
    }
}