using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public float runSpeed = 12f;
    public float jumpPower = 200f;

    [Header("Is object on ground?")]
    public bool ground;

    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
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
            if(ground)
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
