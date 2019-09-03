using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float jumpRaycastDist;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * jumpRaycastDist, Color.blue);
        bool hitGround = Physics.Raycast(transform.position, Vector3.down, jumpRaycastDist);
        return hitGround;
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPos = rb.position + rb.transform.TransformDirection(movement);

        rb.MovePosition(newPos);
    }
}
