using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScript : MonoBehaviour
{

    public Sprite normSprite;
    public Sprite hurtSprite;

    public float randAdd = 0.5f;

    public SpriteRenderer rendr;

    private bool shouldHit = false;
    public int health = 4;
    public float knockback;

    void Awake()
    {

        int i = Random.Range(-1, 1);
        //print(i);

        if ( i == -1)
        {
            randAdd = -randAdd;
        }

        StartCoroutine(Fight());
    }

    IEnumerator Fight()
    {
        while (0 < 1)
        {
            yield return new WaitForSeconds(2 + randAdd);
            shouldHit = true;
            yield return new WaitForSeconds(0.5f);
            shouldHit = false;
        }
        


    }

    private void Hit(GameObject obj)
    {
        if (shouldHit)
        {
            shouldHit = false;

            StartCoroutine(RenderHurt());

            health--;

            if (health == 0)
            {
                Vector2 rel = (Vector2)(transform.position - obj.transform.position).normalized;
                gameObject.GetComponent<explode>().boom(rel*knockback);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ( gameObject.CompareTag("guy") && collision.gameObject.CompareTag("badguy") )
        Hit(collision.gameObject);

        if (gameObject.CompareTag("badguy") && collision.gameObject.CompareTag("guy"))
            Hit(collision.gameObject);
    }


    IEnumerator RenderHurt()
    {
        rendr.sprite = hurtSprite;
        yield return new WaitForSeconds(0.2f);
        rendr.sprite = normSprite;
    }



}
