using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtConvert : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite mudSprite;
    public Collider2D mudCollider;
    public Collider2D dirtCollider;
    public Rigidbody2D body;
    public float snapTime;

    bool isMud = false;
    int consumeCount = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (consumeCount < 3)
        {
            if (collision.gameObject.tag == "water")
            {
                consumeCount++;
                Destroy(collision.gameObject, 0);
            }
        }
        else
        {
            if (isMud == false)
            {
                spriteRenderer.sprite = mudSprite;

                StartCoroutine(SetBodyType());

                isMud = true;
            }
        }
    }

    IEnumerator SetBodyType()
    {
        dirtCollider.enabled = false;
        mudCollider.enabled = true;

        body.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds( snapTime );

        body.bodyType = RigidbodyType2D.Static;
    }

}
