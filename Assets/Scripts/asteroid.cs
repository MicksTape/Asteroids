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

    // Use this for initialization
    void Start () {

        //adds random thurst and rotaion to the astroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);
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

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
