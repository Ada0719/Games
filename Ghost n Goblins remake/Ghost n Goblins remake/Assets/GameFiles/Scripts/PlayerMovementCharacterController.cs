using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modified from:https://github.com/valgoun/CharacterController
/// Article is here: https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483
/// </summary>
public class PlayerMovementCharacterController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;

    public LayerMask Ground;
    public Vector3 Drag;

    public CharacterController controller;
    public Vector3 currentVelocity;
    public bool isGroundedCustom = true;
    public Transform groundChecker;

 
    void Start()
    {
        controller = GetComponent<CharacterController>();
        groundChecker = transform.GetChild(0);
    }

    void Update()
    {
        //You could just use controller.isGrounded but sometimes it does not give you accurate enough feedback
        isGroundedCustom = Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

        currentVelocity.y += Gravity * Time.deltaTime;

        #region Fancy Slope Detection
        //If wanting to be fancy and do stuff on slopes then use the below (it's a bit expensive though)
        //or a more basic version is presented in the PlayerMovementRigidbody class
        //using just colliders
        RaycastHit whatHit;

        //See:https://docs.unity3d.com/ScriptReference/RaycastHit-normal.html
        //See:https://docs.unity3d.com/ScriptReference/Vector3.Angle.html
        if (Physics.Raycast(transform.position, Vector3.down * 5, out whatHit, 5, Ground))
        {
            Vector3 incomingVector = whatHit.point - transform.position;
            Vector3 reflectVector = Vector3.Reflect(incomingVector, whatHit.normal);
            Debug.DrawLine(transform.position, whatHit.point, Color.red);
            Debug.DrawRay(whatHit.point, reflectVector, Color.green);
 
            Vector3 reflectedPosition = whatHit.point + reflectVector;
            Vector3 targetDir = reflectedPosition - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if (angle !=90)
            {
                //"I'm on a slope - do some extra stuff to control me!"
            }
        }
        #endregion

        // hitInfo.point = surface;
        //Vector3 incomingVec = hitInfo.point - this.transform.position;
        //Vector3 reflectVec = Vector3.Reflect(incomingVec, hitInfo.normal);

        //Reset y velocity if touching the ground
        if (isGroundedCustom && currentVelocity.y < 0)
        {
            currentVelocity.y = 0f;
        }

        //Use Input mapping to move left and right
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * Speed);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        //Jump only if grounded
        if (Input.GetButtonDown("Jump") && isGroundedCustom)
        {
            currentVelocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        ////Boost
        //if (Input.GetButtonDown("Fire3"))
        //{
        //    currentVelocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
        //}

        currentVelocity.x /= 1 + Drag.x; 
        currentVelocity.y /= 1 + Drag.y; 
        //currentVelocity.z /= 1 + Drag.z; //Add this if using 3D movememt rather than 2D
        currentVelocity.z = 0;

        controller.Move(currentVelocity * Time.deltaTime);
    }

}
