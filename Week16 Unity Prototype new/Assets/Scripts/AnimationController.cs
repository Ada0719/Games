using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public int state = 0;
    public float speed;
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //Get the game controller
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            state = 1;

        }
        else
        {
            state = 0;
        }

        animator.SetInteger("state", state);

        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 200, 0);
    }

    //To be called when the enemy enters and end the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("lose");

            other.gameObject.GetComponent<EnemyController>().targetCaught = true;
            gc.GameOver(false);

        }
        else if (other.CompareTag("ambulance"))
        {
            gc.GameOver(true);
        }
    }
}
