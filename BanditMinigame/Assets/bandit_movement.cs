﻿using UnityEngine;
using System.Collections;

public class bandit_movement : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float maxSpeed = 5.0f;
    public float rotation = 5.0f;
    public GameObject target;
    public Transform bullet;
    private int timer;

    
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        timer = 0;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn();
        //Debug.Log(timer);
        //shoot();
    }

    float speed() {
        return Random.Range(-6, 6);
    }

    void newCourse()
    {
        float x = speed();
        transform.Rotate(0,0,speed() * rotation);
        timer++;
        maxSpeed = Mathf.Abs(x);
        if (maxSpeed < 1) {
            maxSpeed = 1;
        }
    }

    void move() {
        rb2d.AddForce(transform.right * maxSpeed);
        timer++;
    }
    void brake() {
        rb2d.AddForce(transform.right * -maxSpeed);
        timer++;
    }

    void shoot() {
        transform.LookAt(target.transform.position);
        transform.Rotate(0,-90,0);
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void turn()
    {
        if (timer == 0)
        {
            newCourse();
        }
        else if (timer < 50)
        {
            move();
        }
        else if (timer > 80 && timer < 82)
        {
            shoot();
            timer++;
        }
        else if (timer >= 82)
        {
            timer = 0;
        }
        
        else {
            brake();
        }
    }
}
