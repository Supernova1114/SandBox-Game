using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyMover : MonoBehaviour
{

    public Rigidbody2D body;
    public int sideForce;
    public int upForce;

    //bool col = false;
    //private bool flag = true;

    //private bool isAggressive = false;

    private int rand;

    private GameObject target = null;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Movement()
    {
        while (0 < 1)
        {
            yield return new WaitForSeconds(2);

            GameObject tempTarget = target;

            if (tempTarget == null)
            {
                rand = (int)Random.Range(1, 2.99f);
            }
            else
            {
                if (tempTarget.transform.position.x < transform.position.x)
                {
                    rand = 1;
                }
                else
                {
                    rand = 2;
                }
            }
            

            if (body.velocity.x < 0.2 && body.velocity.y < 0.2)
            {
                if (rand == 1)
                {
                    body.AddForce(new Vector2(-sideForce, upForce));
                }
                else
                {
                    body.AddForce(new Vector2(sideForce, upForce));
                }
            }
            
        }
        


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("guy") && collision.gameObject.CompareTag("badguy"))
        {
            target = collision.gameObject;
        }
        else
        {
            if (gameObject.CompareTag("badguy") && collision.gameObject.CompareTag("guy"))
            {
                target = collision.gameObject;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        col = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        col = false;
    }*/



}
