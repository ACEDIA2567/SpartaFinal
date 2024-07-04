using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 입력 받기
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // 이동 벡터 설정
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용하여 이동
        rb.velocity = movement * moveSpeed;
    }
}
