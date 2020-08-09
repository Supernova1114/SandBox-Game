using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{

    /*private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("water"))
            collided = true;
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("water"))
        {
            transform.position += new Vector3(0, 0.1f, 0);
        }
    }

}
