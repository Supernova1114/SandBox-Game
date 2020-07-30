using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour
{
    public Rigidbody2D body;
    //public Collider2D colliderr;
    //public float snapTime;
    private int collisionCount;

    bool flag = true;

    static bool coool = true;

    private static int count;

    //private bool flag = false;
    //private bool fall = false;

    /*private float waitTime = 2;

    private static float count = 0;
    private static bool flag = true;*/

    //private GameObject waaaa;

    // Start is called before the first frame update
    void Awake()
    {
        //if (gameObject.tag == "water" || gameObject.tag == "acid")
        //waitTime = 0.0f;
        //waaaa = GameObject.Find("Waa");
        //if (gameObject.tag != "water" && gameObject.tag != "acid")

        /* if (gameObject.tag == "water" && gameObject.tag == "acid")
             waitTime = 0.1f;

             SnapAgg();

         if (flag)
         {
             flag = false;
             StartCount();
         }*/

        StartCoroutine(Wait2Sec());

        if (coool)
        {
            coool = false;
            StartCoroutine(counter());
        }

    }

    IEnumerator Wait2Sec()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(LookAtCollisions());
    }

    /*void Update()
    {
        
    }*/


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCount--;

        if (flag == false)
        {
            flag = true;
            Snap();
        }

        *//*if (collisionCount > 0)
        {
            if (flag == false)
            {
                flag = true;
                Snap();
            }
        }*//*
    }*/


    /*private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCount--;
        //if (gameObject.tag != "water" && gameObject.tag != "acid")
        //if ( collisionCount == 1  )

        *//*if ( collisionCount < 2 )
            Snap();*//*

        RaycastHit2D cast = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.12f);
        //count++;
        //print(cast.collider.gameObject);

        //Instantiate(waaaa, cast.point, transform.rotation);

        if (cast.collider == null)
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            //Snap();
        }
        else
        {
            body.bodyType = RigidbodyType2D.Static;
        }*/



        /*if (collisionCount < 3)
        {
            //StopCoroutine(SnapToPosPassive());
            //body.bodyType = RigidbodyType2D.Static;
            
        }*/


    //}


    /*private void StartCount()
    {
        StartCoroutine(PrintCount());
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;

        RaycastHit2D cast = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.12f);
        //count++;
        //print(cast.collider.gameObject);

        //Instantiate(waaaa, cast.point, transform.rotation);

        if (cast.collider == null)
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            //Snap();
        }
        else
        {
            body.bodyType = RigidbodyType2D.Static;
        }
        //body.bodyType = RigidbodyType2D.Static;
    }*/


    IEnumerator LookAtCollisions()
    {
        //yield return new WaitForSeconds(2);

        while (0 < 1)
        {
            yield return new WaitForSeconds(1f);
            bool cont = Cast2();

            if (cont == false)
            {
                StopCoroutine(LookAtCollisions());
                flag = true;
                break;
            }


        }
    }


    private bool Cast()
    {


        if (body.velocity.x < 0.5 && body.velocity.y < 0.5)
        {
            count++;
            //print("cast");
            RaycastHit2D cast = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.12f);


            if (cast.collider == null || (cast.collider.CompareTag("acid") && !gameObject.CompareTag("acid")))
            {
                body.bodyType = RigidbodyType2D.Dynamic;
                return true;
                
            }
            else
            {
                body.bodyType = RigidbodyType2D.Static;
                return false;
            }
        }

        return false;
        
    }




    private bool Cast2()
    {

        if (body.velocity.x < 0.5 && body.velocity.y < 0.5)
        {
            count++;
            //print("cast");
            RaycastHit2D cast1 = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.12f);
            RaycastHit2D cast2 = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 0.12f);
            RaycastHit2D cast3 = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 0.12f);


            bool shouldCast = CheckCasts(cast1, cast2, cast3);


            if (shouldCast || (cast1.collider.CompareTag("acid") && !gameObject.CompareTag("acid")))
            {
                body.bodyType = RigidbodyType2D.Dynamic;
                return true;
            }
            else
            {
                body.bodyType = RigidbodyType2D.Static;
                return false;
            }
        }

        return false;

    }


    private bool CheckCasts(RaycastHit2D cast1, RaycastHit2D cast2, RaycastHit2D cast3)
    {
        if (cast1.collider == null || (cast2.collider == null && cast3.collider == null))
            return true;

        return false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flag)
        {
            flag = false;
            StopCoroutine(LookAtCollisions());
            StartCoroutine(LookAtCollisions());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (flag)
        {
            flag = false;
            StopCoroutine(LookAtCollisions());
            StartCoroutine(LookAtCollisions());
        }
    }


    IEnumerator counter()
    {
        while (0 < 1)
        {
            count = 0;
            yield return new WaitForSeconds(1);
            print(count);
        }

    }


    /*public void Snap() 
    {
        if ( gameObject.activeSelf )
        {
            StopCoroutine(SnapToPos());
            //count++;
            StartCoroutine(SnapToPos());
        }
        
    }*/

    /*public void SnapPas()
    {
        if (gameObject.activeSelf)
        {
            //count++;
            StartCoroutine(SnapToPosPassive());
        }

    }*/


    /*IEnumerator SnapToPosPassive()
    {


        yield return new WaitForSeconds(1f);


        while (0 < 1)
        {


            yield return new WaitForSeconds(waitTime + 3);
            RaycastHit2D cast = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.1f);
            count++;
            //print(cast.collider.gameObject);

            //Instantiate(waaaa, cast.point, transform.rotation);

            if (cast.collider != null)
            {
                body.bodyType = RigidbodyType2D.Static;
                //SnapAgg();
                break;
            }
            else
            {
                body.bodyType = RigidbodyType2D.Dynamic;
            }


        }


    }*/

    /*IEnumerator SnapToPos() 
    {
        *//*if ( flag == true)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.05f);
                if ( collisionCount > 0)
                {
                    fall = false;
                }
                else
                {
                    fall = true;
                }
            }

            if ( fall == true)
            {
                body.bodyType = RigidbodyType2D.Dynamic;
            }
            
        }

        yield return new WaitForSeconds(snapTime);

        body.bodyType = RigidbodyType2D.Static;

        if ( collisionCount == 0)
        {
            Snap();
        }

        //transform.rotation = new Quaternion(0, 0, 0, 0);
        *//*Vector3 ppp = Camera.main.WorldToScreenPoint( 16, 16, 0, Camera.MonoOrStereoscopicEye.Mono);
        Vector3 newPos = transform.position;*//*

        flag = false;*//*

        yield return new WaitForSeconds(1f);


        *//*while ( 0 < 1 )
        {

          
            yield return new WaitForSeconds(waitTime);
            RaycastHit2D cast = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.12f);
            count++;
            //print(cast.collider.gameObject);

            //Instantiate(waaaa, cast.point, transform.rotation);

            if (cast.collider != null)
            {
                body.bodyType = RigidbodyType2D.Static;
                break;
            }
            else
            {
                body.bodyType = RigidbodyType2D.Dynamic;
            }


        }*//*



    }*/


    /*IEnumerator PrintCount()
    {
        while (0 < 1)
        {
            yield return new WaitForSeconds(1f);
            print("Count: " + count);
            count = 0;
        }
        
    }*/


}
