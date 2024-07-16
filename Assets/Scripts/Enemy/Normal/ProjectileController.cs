using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody2D rigid;
    public int power;
    public Vector3 direction;
    private int speed = 7;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision.TryGetComponent<IDamagable>(out IDamagable damagable) && 
        if (collision.gameObject.CompareTag("Player"))
        {
            //damagable.ApplyDamage(power);
            Managers.Pool.Push(gameObject);
            Debug.Log("발사체에 맞음");
        }
    }
}
