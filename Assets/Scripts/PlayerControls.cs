using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Game Controller Object for controlling the game")]
    public GameController gameController;
    [Header("Default Velocity")]
    public float velocity = 5;
    private Rigidbody2D rb;
    private float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        // GameObject.Find("GameController").GetComponent<GameController>().Start();
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }

    //Function where the player collides with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "HighSpike" || collision.gameObject.tag == "LowSpike" || collision.gameObject.tag == "Ground")
        {
            //Game is at a stopping state
            Time.timeScale = 0;
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }
}
