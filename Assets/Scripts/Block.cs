using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject vfxSparkle;
    int health = 3;
    Level level;
    int spriteLevel=-1;
    [SerializeField] Sprite[] hitsprites;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            hitBlock();
        }
    }
    private void hitBlock()
    {
        spriteLevel++;
        health--;
        if (health <= 0)
        {
            DestroyBlock();
        }
        else
        {
            showNexthitsprite();
        }
    }

    private void showNexthitsprite()
    {
        if (hitsprites[spriteLevel] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsprites[spriteLevel];
        }
        else
        {
            Debug.LogError("Sprite not found on gameObject " + gameObject.name);
        }
    }

    private void Start()
    {
        if (tag == "Breakable")
        {
            CountBreakableblocks();
        }
    }

    private void CountBreakableblocks()
    {
        level = FindObjectOfType<Level>();
        level.addBlock();
    }

    private void DestroyBlock()
    {
        level.destroyBlock();
        Destroy(gameObject, 0);
        Triggersparkles();
    }

    private void Triggersparkles()
    {
        GameObject sparkles = Instantiate(vfxSparkle, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
