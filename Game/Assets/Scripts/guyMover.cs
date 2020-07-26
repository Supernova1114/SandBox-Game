using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyMover : MonoBehaviour
{

    public Rigidbody2D body;
    public int sideForce;
    public int upForce;

    //bool col = false;



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
            int rand = (int)Random.Range(1, 2.99f);

            yield return new WaitForSeconds(2);

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

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        col = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        col = false;
    }*/



}
