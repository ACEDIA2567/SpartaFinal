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
    protected EnemyMovement enemyMovement;
    protected EnemyAnimator enemyAnimator;
    public Action attackEvent;
    public Action hitEvent;

    private float attackTime = 0;

    protected virtual void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        attackTime = status.attackSpeed * 2;
    }

    private void Update()
    {
        if (attackTime < 0)
        {
            attackTime = status.attackSpeed * 2;
            enemyMovement.attacking = false;
        }
        else if(attackTime > 0 && enemyMovement.attacking)
        {
            attackTime -= Time.deltaTime;
        }
    }

    protected void OnEnable()
    {
        StartCoroutine(ApplyDamage(5));
    }

    protected void EnemyDie()
    {
        Managers.Pool.Push(gameObject);
    }

    public virtual bool Attack(IDamagable target, float power, int numberOfAttacks = 0)
    {
        //if (target == null) return false;

        //StartCoroutine(target.ApplyDamage(power));

        //enemyMovement.attacking = false;
        return true;
    }

    public virtual IEnumerator ApplyDamage(float dmg)
    {
        if (status.health < 0)
        {
            EnemyDie();
        }
        else
        {
            status.health -= (int)dmg;
            if (!enemyMovement.chase && !enemyMovement.turn)
            {
                enemyMovement.chase = true;
                enemyMovement.trackingTime = 10;
            }
        }
        
        yield return null;
    }
}