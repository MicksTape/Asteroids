using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 direction;
    public float speed;
    public Transform player;


	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {

        //Figure out wich way the player is
        direction = player.position - transform.position;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}
