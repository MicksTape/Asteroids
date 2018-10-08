using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    public GameObject bullet;
    public float bulletForce;

    public float forcedeath;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // inut van keyboard
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //input firew bullet
        if (Input.GetButtonDown("Fire1")){
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet, 3.5f);
        }
        //rotate ship
        transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * -turnThrust);


        // wraping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop){
            newPos.y = screenBottom;
        }

        if (transform.position.y < screenBottom){
            newPos.y = screenTop;
        }

        if (transform.position.x > screenRight){
            newPos.x = screenLeft;
        }

        if (transform.position.x < screenLeft){
            newPos.x = screenRight;
        }

        transform.position = newPos;

    }

    void FixedUpdate()
    {
        
        rb.AddRelativeForce(Vector2.up * thrustInput);
        //rb.AddTorque(-turnInput);

    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.relativeVelocity.magnitude > forcedeath) {

        }
    }

}
