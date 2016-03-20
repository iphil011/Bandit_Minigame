using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed = 2.0f;
    public float rotation = 5.0f;
    public int damageTaken;
    public string axis = "Vertical";
    public GameObject pulse;
    private Vector3 location;
    private float theta;
    private float pause;
    public int shieldCount;
    public int gunCount;
    public GameObject Shield;
    public GameObject spawner;
    public bool arc;
    private Vector3 temp;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        theta = 0;
        for (int i = 0; i < shieldCount; i++)
        {
            GameObject shield = Instantiate(Shield, transform.position, transform.rotation) as GameObject;
            shield.GetComponent<pulse>().player = transform;
            if (arc)
            shield.GetComponent<pulse>().shift = i * 25;
            else
                shield.GetComponent<pulse>().shift = i * 360 / shieldCount;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw(axis);
        float shoot = Input.GetAxis("Fire1");
        Vector2 pos = new Vector2(horizontal, vertical);
        rb2d.AddForce(transform.right * vertical * maxSpeed);
        rb2d.AddTorque(horizontal * rotation);
        theta+= (horizontal/10);
        location = transform.position + transform.right;
        //location.x = transform.position.x + 3 * Mathf.Cos(theta);
        //location.y = transform.position.y + 3 * Mathf.Sin(theta);
        if (pause > 0) {
            pause--;
        }
        if (shoot == 1 && pause <= 0 && gunCount > 0) {
            GameObject newBull = Instantiate(pulse,location, transform.rotation) as GameObject;
            newBull.GetComponent<player_bullet_movement>().spawner = spawner.gameObject;
            pause = 50/gunCount;
        }
        temp = transform.position;

        if (temp.x <= spawner.transform.position.x-10.5f) {
            temp.x = spawner.transform.position.x + 10;
        }
        if (temp.x >= spawner.transform.position.x + 10.5f) {
            temp.x = spawner.transform.position.x -10;
        }
        if (temp.y <= spawner.transform.position.y -10)
        {
            temp.y = spawner.transform.position.y + 9.5f;
        }
        if (temp.y >= spawner.transform.position.y + 10)
        {
            temp.y = spawner.transform.position.y -9.5f;
        }
        transform.position = temp;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bullet") {
            damageTaken++;
            Destroy(other.gameObject);
        }
    }
}
