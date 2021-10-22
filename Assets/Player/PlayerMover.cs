using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float jumpStreght;

    Rigidbody rb;
    bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float axis = Input.GetAxis("Horizontal");
        float translation = transform.position.x + axis * horizontalSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(translation, -4.5f, 4.5f);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(0, 1, 0) * jumpStreght, ForceMode.Impulse);
         
        };
    }
}
