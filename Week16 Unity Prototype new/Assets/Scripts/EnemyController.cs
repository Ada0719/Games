using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    private Transform target;

    public bool targetCaught;

    public float movingSpeed = 1;

    private Vector3 velocity;

    public float angularVelocity = 100;

    public float angleInDegrees = 0;


    void Start()
    {
        targetCaught = false;
    }

    void FixedUpdate()
    {
        //Patrol with a certain rotate speed when no target found
        if (this.target == null)
        {
            //Rotate with the rotate speed
            angleInDegrees += angularVelocity * Time.fixedDeltaTime;
            //Ensure angleInDegrees aways smaller than 360
            angleInDegrees = (angleInDegrees >= 360) ? (angleInDegrees - 360) : angleInDegrees;

            //Get the direction of look At
            float x = transform.position.x + Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);
            float z = transform.position.z + Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
            float y = transform.position.y;

            transform.LookAt(new Vector3(x, y, z));
        }
        //Look at the target and move to him when the target is found
        else
        {
            transform.LookAt(this.target);
            var movement = velocity * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    void LateUpdate()
    {
        // Set target to null and moving velocity to zero by default
        this.target = null;
        velocity = Vector3.zero;

        var visibleTargets = transform.gameObject.GetComponent<FieldOfView>().visibleTargets;

        foreach (var target in visibleTargets)
        {
            //If the target is palyer then aim him and speed up
            if (target.gameObject.CompareTag("Player") && !targetCaught)
            {
                //Set target
                this.target = target;
                var direction = target.position - transform.position;
                //Update the rotate angle
                angleInDegrees = Mathf.Acos(direction.x / direction.magnitude) * Mathf.Rad2Deg;
                //Get the vector of the speed
                velocity = new Vector3(movingSpeed * Mathf.Cos(Mathf.PI / 4), 0, movingSpeed * Mathf.Sin(Mathf.PI / 4));
            }
            else if (targetCaught)
            {
                angularVelocity = 0;
            }
        }
    }

}