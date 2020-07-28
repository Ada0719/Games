using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HairongWu;

namespace HairongWu
{
    /// <summary>
    /// Author: HairongWu
    /// Description: This script demonstrates the basic movement of witch in Unity
    /// </summary>
    public class Enemy : MonoBehaviour
    {

        #region Class Variables aka Static Member Variables 
        #endregion

        #region Instance Variables aka Non-Static Member Variables 
        public int moveSpeed = 2;//enemy moving speed
        public int rotationSpeed = 5;//enemy rotating speed

        private Transform target;//player position
        private Transform myTransform;//enemy position
        private Vector3 targetPosition;

        private void Awake()
        {
            myTransform = transform;//The transform of enemy is attached to myTransform
        }

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("player");//Find the object whose tag is player
            target = player.transform;//define player is the target player
        }

        #endregion




        #region Unity Methods

        public void Update()
        {
            //Debug.DrawLine(target.position, myTransform.position, Color.red);//Draw a straight red line between the player and the enemy for easy viewing

            //Set the enemy to turn around and always face the player
            targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);//get postion of enemy
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(targetPosition - myTransform.position), rotationSpeed * Time.deltaTime);//The enemy turns to face the player

            //Set the enemy to move to the player

            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;//Let the enemy move towards its front

        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("bullet"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

        }
    }





    #endregion


    #region Custom Public Methods 

    #endregion

    #region Custom Private Methods 

    #endregion




}