﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit2 : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;


    public GameObject blueBla;
    public Transform Red;
    //public Transform Blue;

    void Start()
    {
        /*if (gameObject.tag == "Red")
        {
            Blue = GameObject.FindGameObjectWithTag("Blue").transform;
        }
        else if (gameObject.tag == "Blue")
        {*/
            Red = GameObject.FindGameObjectWithTag("Red").transform;
        //}

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        Red = GameObject.FindGameObjectWithTag("Red").transform;
        /*if (gameObject.tag == "Red")
        {
            if (Vector2.Distance(transform.position, Blue.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Blue.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Blue.position) < stoppingDistance && Vector2.Distance(transform.position, Blue.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Blue.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Blue.position, -speed * Time.deltaTime);
            }
        }
        else if (gameObject.tag == "Blue")
        {*/
        if (Vector2.Distance(transform.position, Red.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Red.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Red.position) < stoppingDistance && Vector2.Distance(transform.position, Red.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Red.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Red.position, -speed * Time.deltaTime);
            }
        //}

        if (timeBetweenShots <= 0)
        {
            Instantiate(blueBla, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }



    public int damage = 8;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;

    public int maxHealth = 5;
    public int health { get; set; }

    public void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Pro"))
        {
            //if (this.gameObject.tag == "Red")
            //{ TakeDamage(4); }
        }

        if (collision.CompareTag("Red Pro"))
        {
            //if (this.gameObject.tag == "Blue")
            { TakeDamage(4); }
        }

        if (collision.CompareTag("Blue Bla"))
        {
            //if (this.gameObject.tag == "Red")
            //{ TakeDamage(8); }
        }

        if (collision.CompareTag("Red Bla"))
        {
            //if (this.gameObject.tag == "Blue")
            { TakeDamage(8); }
        }
    }
}
