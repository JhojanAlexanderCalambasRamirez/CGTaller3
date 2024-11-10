using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;
    private float x, y;

    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        // Animaciones
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (Input.GetKey("f"))
        {
            animator.SetBool("Other", false);
            animator.Play("Dance");
        }

        if (x != 0 || y != 0)
        {
            animator.SetBool("Other", true);
        }

        // Detección de suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Salto
        if (Input.GetKey("space") && isGrounded)
        {
            animator.Play("Jump");
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Movimiento usando el Rigidbody
        Vector3 move = transform.forward * y * runSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
