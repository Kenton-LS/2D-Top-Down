using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
