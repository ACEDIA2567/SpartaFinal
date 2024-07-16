using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class NormalEnemy : Enemy, IDamagable
{
    public Action attackEvent;
    public Action hitEvent;
    public Action moveEvent;
    public Action idleEvent;
    public Action dieEvent;

    protected EnemyMovement enemyMovement;
    protected EnemyAnimator enemyAnimator;

    protected float attackTime = 0;

    protected override void Awake()
    {
        base.Awake();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        attackTime = status.attackSpeed * 2;
    }

    private void Start()
    {
        hitEvent += AttackTimeClear;
    }

    protected  void Update()
    {
        if (attackTime < 0)
        {
            AttackTimeClear();
            enemyMovement.attacking = false;
        }
        else if(attackTime > 0 && enemyMovement.attacking)
        {
            attackTime -= Time.deltaTime;
        }
    }

    protected void OnEnable()
    {
        idleEvent?.Invoke();
        StartCoroutine(ApplyDamage(5));
    }

    private void AttackTimeClear()
    {
        attackTime = status.attackSpeed * 2;
    }

    public IEnumerator ApplyDamage(float dmg)
    {
        while(status.health >= 0)
        {
            if (status.health <= dmg)
            {
                dieEvent?.Invoke();
            }
            else
            {
                hitEvent?.Invoke();
                status.health -= (int)dmg;
                if (!enemyMovement.chase && !enemyMovement.turn)
                {
                    enemyMovement.chase = true;
                    enemyMovement.trackingTime = 10;
                }
            }
            yield return new WaitForSeconds(3.0f);
        }   
    }
}