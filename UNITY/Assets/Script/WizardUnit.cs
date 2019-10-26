using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardUnit : MonoBehaviour
{
    private Vector3 Player;
    private Vector2 PlayerDirection;
    private float xDif;
    private float yDif;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.002f;
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player").transform.position;

        xDif = Player.x - transform.position.x;
        yDif = Player.y - transform.position.y;

        PlayerDirection = new Vector2(xDif, yDif);

        transform.Translate(PlayerDirection * speed);
    }

    //
    public int damage = 8;
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
    //
}
