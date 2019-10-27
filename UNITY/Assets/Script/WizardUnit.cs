using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;


    public GameObject blast;
    public Transform RangedUnit;

    void Start()
    {
        RangedUnit = GameObject.FindGameObjectWithTag("RangedUnit").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, RangedUnit.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, RangedUnit.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, RangedUnit.position) < stoppingDistance && Vector2.Distance(transform.position, RangedUnit.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, RangedUnit.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, RangedUnit.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(blast, transform.position, Quaternion.identity);
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
}
