using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public int asteroidSize; // 1 to 3 sizes 3 max!
    public GameObject mediumAsteroid;
    public GameObject smallAsteroid;

    public int points;
    public GameObject player;

    // Use this for initialization
    void Start () {

        //adds random thurst and rotaion to the astroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        //find player
        player = GameObject.FindWithTag("Player");
	}


	
	// Update is called once per frame
	void Update () {

        // wraping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop) {
            newPos.y = screenBottom;
        }

        if (transform.position.y < screenBottom) {
            newPos.y = screenTop;
        }

        if (transform.position.x > screenRight) {
            newPos.x = screenLeft;
        }

        if (transform.position.x < screenLeft) {
            newPos.x = screenRight;
        }

        transform.position = newPos;

    }

    void OnTriggerEnter2D(Collider2D other) {

        //checks tag Bullet 
        if (other.CompareTag("Bullet")) {
            Destroy(other.gameObject);

            // checks different sizes of the asteroids
            if (asteroidSize == 3) {
                Instantiate(mediumAsteroid, transform.position.normalized, transform.rotation);
                Instantiate(mediumAsteroid, transform.position.normalized, transform.rotation);
                
            }
            else if (asteroidSize == 2) {
                Instantiate(smallAsteroid, transform.position.normalized, transform.rotation);
                Instantiate(smallAsteroid, transform.position.normalized, transform.rotation);

            }
            else if (asteroidSize == 1) {

            }
            //Score points
            player.SendMessage("ScorePoints",points);



            //remove asteroid
            Destroy(gameObject);
        }
    }
}
