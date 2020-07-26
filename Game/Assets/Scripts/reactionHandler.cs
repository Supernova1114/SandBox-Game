using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactionHandler : MonoBehaviour
{
    private int timesReacted = 0;

    //public SpriteRenderer guyRenderer;

    //public GameObject guyBoom;

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

        switch (collision.gameObject.tag)
        {
            case "dirt":
                Destroy(collision.gameObject, 1);
                timesReacted++;

                if (timesReacted == 3)
                    Destroy(gameObject);
                break;

            case "guyPiece":
                Destroy(collision.gameObject, 1);
                timesReacted++;

                if (timesReacted == 3)
                    Destroy(gameObject);
                break;

                /*case "guy":
                    GameObject temp = collision.gameObject;

                    Destroy(collision.gameObject, 0f);

                    Instantiate(guyBoom, temp.transform.position, temp.transform.rotation);

                    Destroy(gameObject);
                    break;*/

        }

        /*if ( collision.gameObject.tag == "dirt" || collision.gameObject.tag == "guy")
        {
            Destroy(collision.gameObject, 1);
            timesReacted++;

            if ( timesReacted == 3 )
            Destroy(gameObject);
        }*/
    }


}
