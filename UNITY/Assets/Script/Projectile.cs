﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20;
    public int damage = 4;
    private Transform MeleeUnit;
    private Vector2 target;
    public float distance;
    public LayerMask solids;
    //public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        MeleeUnit = GameObject.FindWithTag("MeleeUnit").transform;

        target = new Vector2(MeleeUnit.position.x, MeleeUnit.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, solids);
        if(hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("MeleeUnit"))
            {
                hitinfo.collider.GetComponent<MeleeUnit>().SendMessage("TakeDamage", damage); //damages enemy player

            }
        }

        //
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MeleeUnit"))
        {
            DestroyProjectile();
            
        }
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
