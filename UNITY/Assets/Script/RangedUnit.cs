using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedUnit : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;


    //public GameObject redPro;
    public GameObject redPro;

    public Transform Blue;
    //public Transform Red;
    

    void Start()
    {
        /*if (this.gameObject.tag == "Red")
        {*/
            Blue = GameObject.FindGameObjectWithTag("Blue").transform;
        /*}

        if (this.gameObject.tag == "Blue")
        {
            Blue = GameObject.FindGameObjectWithTag("Red").transform;
        }*/

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        /*if (this.gameObject.tag == "Red")
        {*/
        Blue = GameObject.FindGameObjectWithTag("Blue").transform;
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
            }/*
        }
    
        if (this.gameObject.tag == "Blue")
        {
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
        }*/

        //


        if (timeBetweenShots <= 0)
        {
            /*if (gameObject.tag == "Blue Pro")
            {
                Instantiate(bluePro, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }
            
            if (gameObject.tag == "Red Pro")
            {*/
                Instantiate(redPro, transform.position, Quaternion.identity); //fire projectile
                timeBetweenShots = startTimeBetweenShots;
            //}
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }



    public int damage = 4;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;

    public int maxHealth = 10;
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blast"))
        {
            TakeDamage(8);

        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Pro"))
        {
            //if (this.gameObject.tag == "Red")
            { TakeDamage(4); }
        }

        if (collision.CompareTag("Red Pro"))
        {
            //if (this.gameObject.tag == "Blue")
            //{ TakeDamage(4); }
        }

        if (collision.CompareTag("Blue Bla"))
        {
            //if (this.gameObject.tag == "Red")
            { TakeDamage(8); }
        }

        if (collision.CompareTag("Red Bla"))
        {
            //if (this.gameObject.tag == "Blue")
            //{ TakeDamage(8); }
        }
    }
}
