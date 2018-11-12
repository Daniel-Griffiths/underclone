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
    private Animator animator;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (canMove) {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            switch ((int) vertical) {
                case (-1):
                    animator.SetBool("WalkDown", true);
                    animator.SetBool("WalkUp", false);
                    break;
                case (1):
                    animator.SetBool("WalkUp", true);
                    animator.SetBool("WalkDown", false);
                    break;
                default:
                    animator.SetBool("WalkDown", false);
                    animator.SetBool("WalkUp", false);
                    break;
            }

            switch ((int)horizontal) {
                case (-1):
                    animator.SetBool("WalkLeft", true);
                    animator.SetBool("WalkRight", false);
                    break;
                case (1):
                    animator.SetBool("WalkRight", true);
                    animator.SetBool("WalkLeft", false);
                    break;
                default:
                    animator.SetBool("WalkLeft", false);
                    animator.SetBool("WalkRight", false);
                    break;
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
