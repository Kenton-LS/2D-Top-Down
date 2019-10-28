using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class MeleeUnit : MonoBehaviour
{
    //public Transform Red;
    public Transform Blue;
    //public Vector2 BlueDirection;
    //public Vector2 RedDirection;
    //private Vector3 RangedUnit;
   // private Vector2 RangedDirection;
    //private float xDif;
    //private float yDif;
    public float speed;
    public float retreatDistance;
    public float stoppingDistance;

    //public Transform target;
    //public float chaseRange;

    private void Start()
    {
        //speed = 0.007f;
        Blue = GameObject.FindGameObjectWithTag("Blue").transform;
    }

    void Update()
    {
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
            transform.position = Vector2.MoveTowards(transform.position, Blue.position, speed * Time.deltaTime);
        }

        //float distanceToTarget = Vector3.Distance(transform.position, target.position);
        //if (distanceToTarget < chaseRange) //chase the closest player
        //{
        /*if (gameObject.tag == "Red")
        {
            */
        //transform.position = Vector2.MoveTowards(transform.position, Blue.position, speed * Time.deltaTime);
        //RangedUnit = GameObject.Find("Blue").transform.position;

        // xDif = RangedUnit.x - transform.position.x;
        // yDif = RangedUnit.y - transform.position.y;

        // RangedDirection = new Vector2(xDif, yDif);
        //transform.Translate(RangedDirection * speed);
        /*   
       }
       else if (gameObject.tag == "Blue")
       {

           transform.position = Vector2.MoveTowards(transform.position, Red.position, speed * Time.deltaTime);

       }*/

        float distanceToTarget = Vector3.Distance(transform.position, Blue.position);
         if (distanceToTarget < attackDelay)
         {
         if (Time.time > lastAttackTime + attackDelay)
          {
             Blue.SendMessage("TakeDamage", damage); //tell enemy to be damaged
            lastAttackTime = Time.time; //get physical clock of last attack
         }
     }
    }

    //
    public int damage = 2;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;

    public int maxHealth = 20;
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
    //
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
