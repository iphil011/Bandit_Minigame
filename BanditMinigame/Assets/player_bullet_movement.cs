using UnityEngine;
using System.Collections;

public class player_bullet_movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed = 10.0f;
    public GameObject spawner;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(transform.right * maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > spawner.transform.position.x + 15 || transform.position.x < spawner.transform.position.x - 15 || transform.position.y > spawner.transform.position.y + 15 || transform.position.y < spawner.transform.position.y - 15)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
