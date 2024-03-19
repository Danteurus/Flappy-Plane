using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public float flapStrength;
    public logicScript logic;
    public bool planeIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && planeIsAlive)
        {
            myRigibody.velocity = Vector2.up * flapStrength;
        }
        outOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        planeIsAlive = false;
    }

    private void outOfBounds()
    {
        if (transform.position.y > 50 || transform.position.y < -50)
        {
            logic.gameOver();
            planeIsAlive = false;
        }
    }
}
