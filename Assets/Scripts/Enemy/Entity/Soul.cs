using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    public Transform target;
    private int speed = 10;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        float posX = Random.Range(-1f, 1f);
        float posY = Random.Range(-1f, 1f);
        Vector3 sumPos = new Vector3(posX, posY, 0);

        rigid.AddForce(sumPos * 5, ForceMode2D.Impulse);
        Invoke("OnAnimator", Random.Range(0.7f, 1.0f));
    }

    private void OnAnimator()
    {
        animator.enabled = true;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(target.position, transform.position) < 5)
        {
            rigid.velocity = (target.position - transform.position).normalized * speed;
        }
    }

    public void GetTarget(Transform transform)
    {
        target = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Managers.Pool.Push(gameObject);
        }
    }
}
