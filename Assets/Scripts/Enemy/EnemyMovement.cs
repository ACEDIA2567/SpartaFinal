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

    private Vector3 startPos; // ���� ����
    private WaitForSeconds delay = new WaitForSeconds(0.02f);

    // �÷��̾� �߰� ����
    public bool chase = false;
    public bool attacking = false;
    public bool turn = false;
    public float trackingTime = 0.0f;
    public Vector3 direction; // �߰� ����
    private Vector3 leftDirection; // ���� �߰� ����
    private Vector3 rightDirection; // ������ �߰� ����
    private Vector3 leftRot = new Vector3(0, 0, 45f);
    private Vector3 rightRot = new Vector3(0, 0, -45f);
    private Vector3 leftTurnRot = new Vector3(0, 0, 65f);
    private Vector3 rightTurnRot = new Vector3(0, 0, -65f);

    private Vector2 size = new Vector2(2f, 2);

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ÿ�� ��ġ ����
        // �̱��� �Ǵ� Find�� �÷��̾� ��ġ �˻�
        target = GameObject.Find("Player").transform;
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
            chase = false;
            turn = true;
        }
    }

    protected void OnEnable()
    {
        if (enemy.status.monsterType != MonsterType.Boss)
        {
            StartCoroutine(RayPlayer());
            startPos = transform.position;
        }
    }

    // OnDrawGizmos()�� Scene â���� ������ Ȯ���ϱ� ����
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Movement(Vector3 pos)
    {
        float distance = pos.magnitude;
        if (distance < enemy.status.attackRange && chase)
        {
            TargetMove(Vector2.zero);
            Rotate(Vector2.zero);
            if (!attacking)
            {
                attacking = true;
                enemy.attackEvent?.Invoke();
            }
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
        rigid.velocity = direction * enemy.status.moveSpeed;
    }

    // Ray�� �÷��̾�
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

            yield return delay;
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
