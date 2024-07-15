using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // && TryGetComponent<IDamagable>(out IDamagable damagable)
        if (collision.CompareTag("Player") )
        {
            // damagable.ApplyDamage(power);
            Debug.Log("플레이어 근접 공격 맞음");
        }
    }
}
