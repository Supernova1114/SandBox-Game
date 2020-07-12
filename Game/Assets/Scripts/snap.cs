using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap : MonoBehaviour
{
    public Rigidbody2D body;
    public Collider2D colliderr;
    public float snapTime;
    private int collisionCount;
    private bool flag = false;
    private bool fall = false;

    // Start is called before the first frame update
    void Awake()
    {
        Snap();
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
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

        /*if (collisionCount > 0)
        {
            if (flag == false)
            {
                flag = true;
                Snap();
            }
        }*/
    }


    public void Snap() 
    {
        StartCoroutine(SnapToPos());
    }


    IEnumerator SnapToPos() 
    {
        if ( flag == true)
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
        /*Vector3 ppp = Camera.main.WorldToScreenPoint( 16, 16, 0, Camera.MonoOrStereoscopicEye.Mono);
        Vector3 newPos = transform.position;*/

        flag = false;
    }

}
