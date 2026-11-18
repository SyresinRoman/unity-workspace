using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float mouseY = 0;
    private bool isGrounded = false;
    private Vector3 movement = Vector3.zero;

    [Header("Настройки движения")]
    public float moveSpeed = 3f;
    public float jumpPower = 5f;
    // Точка ног нашего персонажа
    public Transform legs;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = Vector3.zero;

        // Касаемся ли земли
        //isGrounded = Physics.Linecast(legs.position, legs.position + Vector3.down * 0.1f);

        // Считываем кнопки
        if (Input.GetKey(KeyCode.W)) movement.z = 1;
        if (Input.GetKey(KeyCode.S)) movement.z = -1;
        if (Input.GetKey(KeyCode.D)) movement.x = 1;
        if (Input.GetKey(KeyCode.A)) movement.x = -1;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) rb.AddForce(transform.up * jumpPower);

        movement = transform.TransformDirection(movement);
        movement.Normalize();
        movement *= moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
