using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocker : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject playerObj;
    public player playerMovement;
    public GameObject storageObj;
    public string difficulty = "hard";
    public int speed = -5000;
    public int score = 0;
    public float[] positions = new float[7];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = -((i + i) + 67.51f);
            Debug.Log(positions[i]);
        }
        storageObj = GameObject.FindGameObjectsWithTag("storage")[0];
        playerObj = GameObject.FindGameObjectsWithTag("hi")[0];
        playerMovement = playerObj.GetComponent<player>();
        rb = GetComponent<Rigidbody>();
        difficulty = storageObj.gameObject.name;
        Debug.Log(difficulty);
        if (difficulty.Equals("easy"))
        {
            speed = -50000;
        }
        else if (difficulty.Equals("medium"))
        {
            speed = -75000;
        }
        else
        {
            speed = -100000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(0, 0, speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        this.transform.position = new Vector3(-66.27503f, 144.0386f, -184.7089f);
        string objName = collision.gameObject.name;
        //Change to lose life or end game when touching player
        if (objName.Equals("scoreSensor") || objName.Equals("player")) 
        {
            int randomPosition = Random.Range(1, positions.Length - 1);
            Debug.Log(positions[randomPosition]);
            this.transform.position = new Vector3(positions[randomPosition], 7.87f, -36.4f);
        }
    }
}
