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

    private ArrayList collList = new ArrayList();

    void Awake()
    {

        int i = Random.Range(-1, 1);
        //print(i);

        if ( i == -1)
        {
            randAdd = -randAdd;
        }

        StartCoroutine(Fight());
        StartCoroutine(HitLoop());
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


    GameObject temp;
    IEnumerator HitLoop()
    {
        while (0 < 1) 
        {
            yield return new WaitForSeconds(0.1f);

            
            foreach (GameObject item in collList)
            {
                if (item.gameObject != null && (item.CompareTag("guy") || item.CompareTag("badguy")))
                    temp = item;
            }

            if (temp != null && gameObject.CompareTag("guy") && temp.CompareTag("badguy"))
                Hit(temp);

            if (temp != null && gameObject.CompareTag("badguy") && temp.CompareTag("guy"))
                Hit(temp);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collList.Add(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collList.Remove(collision.gameObject);
    }


    IEnumerator RenderHurt()
    {
        rendr.sprite = hurtSprite;
        yield return new WaitForSeconds(0.2f);
        rendr.sprite = normSprite;
    }



}
