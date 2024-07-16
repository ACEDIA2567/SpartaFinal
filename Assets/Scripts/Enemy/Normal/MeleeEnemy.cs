using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : NormalEnemy
{
    [SerializeField]
    private GameObject attackRange;

    protected override void Awake()
    {
        base.Awake();
    }

    private void AttackRangeActive()
    {
        attackRange.SetActive(false);
    }

    private void AttackStart()
    {
        attackRange.SetActive(true);
        attackRange.transform.position = transform.position;
        attackRange.transform.Translate(enemyMovement.direction.normalized / 2);
        attackRange.GetComponent<MeleeAttack>().power = status.attack;
    }
}
