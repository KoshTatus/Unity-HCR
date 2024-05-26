using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D carRB;
    [SerializeField] private float speed = 200f;
    [SerializeField] private float rotationSpeed = 500f;
    private float moveInput;
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        frontTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        backTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carRB.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);
    }
}
