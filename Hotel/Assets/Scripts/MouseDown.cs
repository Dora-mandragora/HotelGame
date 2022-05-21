using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    private Rigidbody rb;
    private float mouseX;
    private float mouseY;
    private float speed = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDown()
    {                
        //rb.AddForce(new Vector3(mouseX,100,mouseY), ForceMode.Force);        
        //rb.MovePosition(new Vector3(mouseX, mouseY));
    }
}
