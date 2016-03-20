using UnityEngine;
using System.Collections;

public class bullet_movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed = 15.0f;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.AddForce(transform.right * maxSpeed);
        if (transform.position.x > 15 || transform.position.x < -15 || transform.position.y > 15 || transform.position.y < -15) {
            Destroy(this.gameObject);
        }
    }

    
    
}
