using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{

    public Rigidbody2D body;
    public CircleCollider2D colliderr2D;
    public float force;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(WaterColl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
            colliderr2D.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            collision.gameObject.GetComponent<snap>().body.bodyType = RigidbodyType2D.Dynamic;

            body.bodyType = RigidbodyType2D.Dynamic;
            body.AddForce(new Vector2(0, force));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        colliderr2D.isTrigger = false;
    }*/


    IEnumerator WaterColl()
    {

        while (0 < 1)
        {
            yield return new WaitForSeconds(0.1f);
            Cast();
            //yield return new WaitForSeconds(0.1f);
            //colliderr2D.isTrigger = false;


        }
    }

    private void Cast()
    {
        RaycastHit2D cast;

        if (body.velocity.x < 0.5 && body.velocity.y < 0.5)
        {
            //print("cast");
            RaycastHit2D cast1 = Physics2D.Raycast(gameObject.transform.position, Vector2.up, 0.12f);
            RaycastHit2D cast2 = Physics2D.Raycast(gameObject.transform.position, Vector2.left, 0.12f);
            RaycastHit2D cast3 = Physics2D.Raycast(gameObject.transform.position, Vector2.right, 0.12f);

            cast = CheckCasts(cast1, cast2, cast3);

            if ( cast.collider != null )
            {
                //colliderr2D.isTrigger = true;

                cast.collider.gameObject.GetComponent<snap>().body.bodyType = RigidbodyType2D.Dynamic;
                body.bodyType = RigidbodyType2D.Dynamic;

                transform.position += new Vector3(0, 0.2f, 0);
                //body.AddForce(new Vector2(0, force));

            }
        }

    }

    private RaycastHit2D CheckCasts(RaycastHit2D cast1, RaycastHit2D cast2, RaycastHit2D cast3)
    {
        if (cast1.collider != null && cast1.collider.CompareTag("water"))
            return cast1;
        if (cast2.collider != null && cast2.collider.CompareTag("water"))
            return cast2;
        if (cast3.collider != null && cast3.collider.CompareTag("water"))
            return cast3;

        return new RaycastHit2D();
    }



}
