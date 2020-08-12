using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//scene restarter is in the textChanges script
public class player : MonoBehaviour {
    public Rigidbody rb;
    public float movementForce = 45f;
    public float foreverForce = 3000f;
    public bool canMove = true;
    public bool gameOver = false;
    public bool hasStarted = false;
    public int difficulty = 1;
    public bool playInstructions = false;
    public int frameCount = 0;
    public int coins = 0;
    public int score = 0;
    //CHANGE BASED ON LIVES SETTING:
    public int lives = 3;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, 0);
        if (Input.GetKey("right"))
        {
            if (transform.position.x <= -68.7)
            {
                Debug.Log("right");
                rb.AddForce(new Vector3(75000 * Time.deltaTime, 0, 0));
            }
        }
        if (Input.GetKey("left"))
        {
            if (transform.position.x >= -76.95)
            {
                Debug.Log("left");
                rb.AddForce(new Vector3(-75000 * Time.deltaTime, 0, 0));
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Debug.Log("DED");
            lives--;
        }
    }

}
