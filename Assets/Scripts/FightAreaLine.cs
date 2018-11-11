using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightAreaLine : MonoBehaviour {

    private float speed = 1f;

    private Vector3 start;
    private Vector3 end;
    private float fraction = 0;
    private Vector2 initialPosition;

    void Start()
    {
        Vector2 fightArea = GameObject.FindGameObjectWithTag("FightArea").GetComponent<SpriteRenderer>().bounds.size;
        initialPosition = transform.position;
        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        end = new Vector3(transform.position.x + fightArea.x, transform.position.y, transform.position.z);
    }

    void Update()
    {

        if (fraction < 1) {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start, end, fraction);
        } else {
            fraction = 0;
            transform.position = initialPosition;
        }
    }
}
