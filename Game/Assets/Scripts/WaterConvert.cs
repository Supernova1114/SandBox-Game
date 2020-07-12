using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterConvert : MonoBehaviour
{
    public Collider2D colliderr;
    public GameObject acid;

    private bool hasCollided = false;


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
        if ( collision.gameObject.tag == "acid")
        {
            if (hasCollided == false)
            {
                hasCollided = true;

                //colliderr.enabled = false;
                Instantiate(acid, transform.position, transform.rotation);

                //collision.gameObject.GetComponent<snap>().Snap();

                Destroy(gameObject, 0f);
            }
        }
    }


}
