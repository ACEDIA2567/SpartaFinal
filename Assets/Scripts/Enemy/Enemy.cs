using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    public EnemyStatus status;
    protected EnemyMovement enemyMovement;
    protected EnemyAnimator enemyAnimator;
    public Action attackEvent;
    public Action hitEvent;
    public Action moveEvent;
    public Action idleEvent;
    public Action dieEvent;

    private float attackTime = 0;

    protected virtual void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        attackTime = status.attackSpeed * 2;
    }

    private void Start()
    {
        hitEvent += AttackTimeClear;
    }

    private void Update()
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
        StartCoroutine(ApplyDamage(1));
    }

    private void AttackTimeClear()
    {
        attackTime = status.attackSpeed * 2;
    }

    private void EnemyDie()
    {
        Managers.Pool.Push(transform.parent.gameObject);
    }


    public IEnumerator ApplyDamage(float dmg)
    {
        while(status.health >= 0)
        {
            if (status.health <= 0)
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