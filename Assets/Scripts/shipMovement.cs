using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shipMovement : MonoBehaviour {

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

    private int lives= 3;
    private int score;

    public Text scoreText;
    public Text livesText;
    public GameObject gameOverScreen;

    public Color immortalColor;
    public Color normalColor;

    // Use this for initialization
    void Start () {
        score = 0;

        scoreText.text = "Score " + score;
        livesText.text = "Lives " + lives;
		
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

    void ScorePoints(int addPoints) {
        score += addPoints;
        scoreText.text = "Score " + score;
    }

    void Respawn() {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        sr.color = immortalColor;
        Invoke ("Immortal", 3f);
    }

    void Immortal() {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.relativeVelocity.magnitude > forcedeath) {
            lives--;
            livesText.text = "Live " + lives;
            //Respawn
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke("Respawn", 3f);

            if (lives <= 0) {
                //death
                GameOver();
            }
        }
    }

    void GameOver() {
        CancelInvoke();
        gameOverScreen.SetActive(true);
    }

    public void TryAgain() {
        SceneManager.LoadScene("Main");
    }

}
