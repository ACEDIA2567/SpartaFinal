using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Enemy enemy;
    Animator animator;

    private static readonly int isMove = Animator.StringToHash("IsMove");
    private static readonly int isHit = Animator.StringToHash("IsHit");
    private static readonly int isDie = Animator.StringToHash("IsDie");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        enemy.attackEvent += Attacking;
        enemy.hitEvent += Hit;
    }

    private void Move()
    {
        animator.SetBool(isMove, true);
    }

    private void Attacking()
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void Die()
    {
        animator.SetBool(isDie, true);
    }
}
