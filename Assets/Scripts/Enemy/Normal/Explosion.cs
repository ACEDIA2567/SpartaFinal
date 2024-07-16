using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour, IAttackable
{
    [SerializeField]
    GameObject min;
    [SerializeField]
    GameObject max;

    public int power;
    private Vector3 addVector3 = new Vector3(0.1f, 0.1f, 0.1f);

    private IDamagable target;

    private void OnEnable()
    {
        min.transform.localScale = addVector3;
    }

    void Update()
    {
        if (min.transform.localScale.magnitude >= max.transform.localScale.magnitude)
        {
            if(Attack(target, power, 0))
            {
                target.ApplyDamage(power);
            }
            Managers.Pool.Push(gameObject);
        }
        else
        {
            min.transform.localScale += addVector3 * Time.deltaTime * 5;
        }
    }

    public bool Attack(IDamagable target, float power, int numberOfAttacks)
    {
        if (target == null) return false;

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.TryGetComponent<IDamagable>(out IDamagable damagable) && 
        if (collision.gameObject.CompareTag("Player"))
        {
            //target = damagable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // collision.TryGetComponent<IDamagable>(out IDamagable damagable) && 
        if (collision.gameObject.CompareTag("Player"))
        {
            //target = damagable;
            Debug.Log("ÆøÅº °ø°Ý ¹üÀ§ ³ª°¨");
        }
    }
}
