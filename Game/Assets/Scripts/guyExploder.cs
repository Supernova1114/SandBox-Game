using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyExploder : MonoBehaviour
{
    public float explosionMult;
    public bool isBattleMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendForce(Vector2 rel)
    {

        Vector2 vec = rel * explosionMult;
        BroadcastMessage("AddForce", vec);
    }

}
