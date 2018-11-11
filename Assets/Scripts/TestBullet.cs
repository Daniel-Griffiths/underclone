using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour {

    private GameObject player;
    public float followSpeed;
    private const float bulletLifetime = 4f;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        // Destroy bullet after x seconds
       // Invoke("DestroyBullet", bulletLifetime);

        // Aim bullet in player's direction.
        //transform.rotation = Quaternion.LookRotation(player.transform.position, Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up * -.5f * Time.deltaTime;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
