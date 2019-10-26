﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeUnit : MonoBehaviour
{
    private Vector3 Player;
    private Vector2 PlayerDirection;
    private float xDif;
    private float yDif;
    private float speed;

    private void Start()
    {
        speed = 0.004f;
    }

    void Update()
    {
        Player = GameObject.Find("Player").transform.position;

        xDif = Player.x - transform.position.x;
        yDif = Player.y - transform.position.y;

        PlayerDirection = new Vector2(xDif, yDif);

        transform.Translate(PlayerDirection * speed);
    }
}