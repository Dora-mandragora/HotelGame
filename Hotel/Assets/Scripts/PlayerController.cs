using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public float runSpeed = 12f;
    public float gravity = 20f;
    public float jumpPower = 200f;

    private Vector3 moveDir = Vector3.zero;

    private CharacterController controller;
    private Rigidbody rigidbody;

    public bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            if(Input.GetKey(KeyCode.LeftShift)) moveDir *= runSpeed;
            else moveDir *= speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpPower;
        }
        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);

        //GetInput();
    }

    private void GetInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            MovePlayer(transform.forward);            
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(-transform.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(-transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(transform.right);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                rigidbody.AddForce(transform.up * jumpPower);
            }
        }
    }

    private void RotationMove(Vector3 direction, float localSpeed)
    {
        transform.localPosition += direction * Time.deltaTime * localSpeed;
    }

    private void MovePlayer(Vector3 direction)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RotationMove(direction, runSpeed);
        }
        else
        {
            RotationMove(direction, speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
}
