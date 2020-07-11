using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childController : MonoBehaviour
{
    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        //body = gameObject.GetComponent<Rigidbody2D>();
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
