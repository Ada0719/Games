using UnityEngine;
using System.Collections;
using System;

public class Controller : MonoBehaviour
{

    public float moveSpeed = 6;

    Rigidbody myRigidbody;
    Camera viewCamera;
    Vector3 velocity;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void Update()
    {
       // Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
       // transform.LookAt(mousePos + Vector3.up * transform.position.y);
       // transform.LookAt(mousePos);
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
}