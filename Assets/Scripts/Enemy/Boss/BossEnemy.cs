using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy, IDamagable
{



    public IEnumerator ApplyDamage(float dmg)
    {
        while (status.health >= 0)
        {
            if (status.health <= dmg)
            {
                // Á×À½
            }
            else
            {
                status.health -= (int)dmg;
            }
            yield return new WaitForSeconds(3.0f);
        }
    }
}