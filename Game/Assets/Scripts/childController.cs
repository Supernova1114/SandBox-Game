using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childController : MonoBehaviour
{
    public Rigidbody2D body;

    void Awake()
    {
        if ( gameObject.GetComponentInParent<guyExploder>().isBattleMode)
        {
            Destroy(gameObject, 5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void AddForce(Vector2 force)
    {
        body.AddForce(force);
    }


}
