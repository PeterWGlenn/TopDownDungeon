﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //  Reset move delta
        moveDelta = new Vector3(x,y,0);

        // Swap Sprite Direction
        if(moveDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        // Check if player can move in the y direction by casting a box there first. If the box returns null, player can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null)
        {
            // Player Movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Check if player can move in the x direction by casting a box there first. If the box returns null, player can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Player Movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        

    }

}
