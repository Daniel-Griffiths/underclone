using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int health = 10;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float vertical;
    private float horizontal;
    public bool canMove = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (canMove) {
            if (Input.GetKey("up") || Input.GetKey("w")) {
                vertical = 1;
            } else if (Input.GetKey("down") || Input.GetKey("s")) {
                vertical = -1;
            } else {
                vertical = 0;
            }

            if (Input.GetKey("left") || Input.GetKey("a")) {
                horizontal = -1;
            } else if (Input.GetKey("right") || Input.GetKey("d")) {
                horizontal = 1;
            } else {
                horizontal = 0;
            }
        }

        rb.velocity = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown("e")) {
            Interact();
        }
    }

    public void StopMoving()
    {
        this.horizontal = 0;
        this.vertical = 0;
        this.canMove = false;
    }

    void Interact()
    {

    }
}
