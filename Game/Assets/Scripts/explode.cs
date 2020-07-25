using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{

    public Rigidbody2D body;
    
    public GameObject guyPieces;

    private bool flag = true;

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
        if (collision.gameObject.CompareTag("acid"))
        {
            if (flag)
            {
                flag = false;
                boom();
            }
        }
    }

    private void boom()
    {
        body.simulated = false;
        Instantiate(guyPieces, transform.position, transform.rotation);
        Destroy(gameObject, 0);
    }

}
