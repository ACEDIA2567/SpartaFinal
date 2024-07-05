using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public EnemyStatus status;
    private float trackingTime = 10.0f;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        // 타겟 위치 설정
        // 싱글톤 또는 Find로 플레이어 위치 검색
        target = GameObject.Find("Player").transform;
    }

    protected virtual void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        TargetMove(direction);
        Rotate(direction);
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
        gameObject.SetActive(false);
    }

    // IDamagable

    // IAttackable
}