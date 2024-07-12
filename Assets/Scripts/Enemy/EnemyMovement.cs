using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    public Transform target;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigid;

    public Vector3 startPos; // 시작 지점
    private WaitForSeconds delay = new WaitForSeconds(0.02f);
    private Vector3 flipX = new Vector3(1, 1, 1);
    private float tolerance = 0.1f; // 거리 임계값

    // 플레이어 추격 관련
    public bool moveStop = false;
    public bool chase = false;
    public bool attacking = false;
    public bool turn = false;
    public float trackingTime = 0.0f;
    public Vector3 direction; // 추격 방향
    private Vector3 leftDirection; // 왼쪽 추격 방향
    private Vector3 rightDirection; // 오른쪽 추격 방향
    private Vector3 leftRot = new Vector3(0, 0, 45f);
    private Vector3 rightRot = new Vector3(0, 0, -45f);
    private Vector3 leftTurnRot = new Vector3(0, 0, 65f);
    private Vector3 rightTurnRot = new Vector3(0, 0, -65f);

    // Ray 및 Collider관련
    private Vector2 size = new Vector2(2f, 2);
    private RaycastHit2D hitDirection;
    private RaycastHit2D hitLeftDir;
    private RaycastHit2D hitRightDir;

    // Layer관련
    private int enemyLayer;
    private int wallLayer;
    private int sumLayer;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        enemyLayer = LayerMask.NameToLayer("Enemy");
        wallLayer = LayerMask.NameToLayer("Wall");
        sumLayer = LayerMask.GetMask("Enemy", "Wall");
        // 타겟 위치 설정
        // 싱글톤 또는 Find로 플레이어 위치 검색
        target = GameObject.Find("Player").transform;
        enemy.attackEvent += MoveStopChange;
        enemy.hitEvent += MoveStopChange;
        enemy.dieEvent += MoveStopChange;
    }

    protected void FixedUpdate()
    {
        if (trackingTime > 0)
        {
            if (!attacking)
            {
                trackingTime -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (chase)
            {
                turn = true;
                chase = false;
            }
        }
    }

    protected void OnEnable()
    {
        moveStop = true;
        if (enemy.status.monsterType != MonsterType.Boss)
        {
            StartCoroutine(RayPlayer());
            startPos = transform.position;
        }
    }

    // OnDrawGizmos()는 Scene 창에서 눈으로 확인하기 위함
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.position, size);
    //}

    private void MoveStopChange()
    {
        if (moveStop)
        {
            moveStop = false;
        }
        else
        {
            moveStop = true;
        }
    }

    private void Movement(Vector3 pos)
    {
        float distance = pos.magnitude;
        if (distance < enemy.status.attackRange && chase)
        {
            TargetMove(Vector2.zero);
            Rotate(pos);
            if (!attacking)
            {
                attacking = true;
                enemy.attackEvent?.Invoke();
            }
            else
            {
                enemy.idleEvent?.Invoke();
            }
        }
        else if (!chase && pos.magnitude < tolerance)
        {
            enemy.idleEvent?.Invoke();
            TargetMove(Vector2.zero);
            Rotate(Vector2.zero);
            turn = false;
        }
        else
        {
            enemy.moveEvent?.Invoke();
            pos.Normalize();
            TargetMove(pos);
            Rotate(pos);
        }
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        flipX.x = Mathf.Abs(rotZ) > 90f ? 1 : -1;
        transform.localScale = flipX;
        // spriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    protected void TargetMove(Vector2 direction)
    {
        rigid.velocity = direction * enemy.status.moveSpeed * (moveStop ? 1 : 0);
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

            hitDirection = Physics2D.Raycast(transform.position, direction, circleCollider2D.radius, LayerMask.GetMask("Wall"));
            //Debug.DrawRay(transform.position, direction.normalized * circleCollider2D.radius, Color.red, 0.1f);
            //Debug.DrawRay(transform.position, leftDirection.normalized * circleCollider2D.radius, Color.blue, 0.1f);
            //Debug.DrawRay(transform.position, rightDirection.normalized * circleCollider2D.radius, Color.blue, 0.1f);
            Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, LayerMask.GetMask("Wall"));
            if (hitDirection.collider != null || hit?.gameObject != null)
            {
                hitLeftDir = Physics2D.Raycast(transform.position, leftDirection, circleCollider2D.radius, LayerMask.GetMask("Wall"));
                hitRightDir = Physics2D.Raycast(transform.position, rightDirection, circleCollider2D.radius, LayerMask.GetMask("Wall"));
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

            yield return delay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!chase && !turn)
            {
                trackingTime = 10;
                chase = true;
            }
        }
    }
}
