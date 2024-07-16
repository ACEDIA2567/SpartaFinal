using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    void Start()
    {
        GameObject SpawnProjectile = Resources.Load<GameObject>($"Projectile/Arrow");
        Managers.Pool.CreatePool(SpawnProjectile, 20);
        GameObject SpawnExplosion = Resources.Load<GameObject>($"Projectile/Explosion");
        Managers.Pool.CreatePool(SpawnExplosion, 20);
        GameObject SpawnSoul = Resources.Load<GameObject>($"Entity/Soul");
        Managers.Pool.CreatePool(SpawnSoul, 20);
    }
}
