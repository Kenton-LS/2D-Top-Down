using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class MeleeUnit : MonoBehaviour
{
    private Vector3 RangedUnit;
    private Vector2 RangedDirection;
    private float xDif;
    private float yDif;
    private float speed;

    public Transform target;
    public float chaseRange;

    private void Start()
    {
        speed = 0.004f;
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(distanceToTarget < chaseRange) //chase the closest player
        {
            RangedUnit = GameObject.Find("RangedUnit").transform.position;

            xDif = RangedUnit.x - transform.position.x;
            yDif = RangedUnit.y - transform.position.y;

            RangedDirection = new Vector2(xDif, yDif);

            transform.Translate(RangedDirection * speed);/*
            Vector3 targetDir = target.position - transform.position;
           float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * speed);*/
        }

        //float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < attackDelay)
        {
            if (Time.time > lastAttackTime + attackDelay)
            {
                target.SendMessage("TakeDamage", damage); //tell enemy to be damaged
                lastAttackTime = Time.time; //get physical clock of last attack
            }
        }
    }

    //
    public int damage;
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
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    //
}
