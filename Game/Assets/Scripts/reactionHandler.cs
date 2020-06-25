using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactionHandler : MonoBehaviour
{
    private int timesReacted = 0;

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
        if ( collision.gameObject.tag == "dirt")
        {
            Destroy(collision.gameObject, 1);
            timesReacted++;

            if ( timesReacted == 3 )
            Destroy(gameObject);
        }
    }


}
