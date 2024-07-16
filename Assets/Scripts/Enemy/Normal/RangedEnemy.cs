using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : NormalEnemy
{
    [SerializeField]
    private GameObject projectile;
    public bool AttackType = false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void SpawnProjectile()
    {
        if(AttackType == false)
        {
            GameObject tile = Managers.Pool.Pop(projectile, transform.parent).gameObject;
            tile.transform.position = transform.position;
            enemyMovement.direction.Normalize();
            tile.GetComponent<ProjectileController>().direction = enemyMovement.direction;
        }
        else
        {
            GameObject tile = Managers.Pool.Pop(projectile, transform.parent).gameObject;
            tile.transform.position = target.position;
        }
    }

}

