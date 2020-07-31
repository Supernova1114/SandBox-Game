using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHandler : MonoBehaviour
{

    public SpriteRenderer rendererr;
    public Sprite fire1, fire2, fire3, oil;

    public float burnTime;

    private bool flag = true;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (flag && collision.gameObject.CompareTag("fire"))
        {
            flag = false;
            tag = "fire";
            
            StartCoroutine(FireAnimation());
        }
    }


    IEnumerator FireAnimation()
    {

        Destroy(gameObject, burnTime);
        while (0 < 1)
        {
            rendererr.sprite = fire1;
            yield return new WaitForSeconds(0.1f);
            rendererr.sprite = fire2;
            yield return new WaitForSeconds(0.1f);
            rendererr.sprite = fire3;
            yield return new WaitForSeconds(0.1f);
        }

        

    }


}
