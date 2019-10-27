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


    public GameObject projectile;
    public Transform MeleeUnit;

    void Start()
    {
        MeleeUnit = GameObject.FindGameObjectWithTag("MeleeUnit").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, MeleeUnit.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, MeleeUnit.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, MeleeUnit.position) < stoppingDistance && Vector2.Distance(transform.position, MeleeUnit.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, MeleeUnit.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, MeleeUnit.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blast"))
        {
            TakeDamage(4);

        }
    }
}
