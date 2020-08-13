using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilHandler : MonoBehaviour
{

    public SpriteRenderer rendererr;
    public Sprite fire1, fire2, fire3, oil;
    public Rigidbody2D body;

    private ArrayList collList = new ArrayList();

    public float burnTime;

    private bool flag = true;

    private int collNum = 0; //num of colliding objs

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkForColl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator checkForColl()
    {
        while (0 < 1)
        {

            yield return new WaitForSeconds(0.5f);

            foreach (Collider2D item in collList)
            {
                if (item.gameObject != null && item.gameObject.CompareTag("water"))
                {
                    transform.position += new Vector3(0, 0.1f, 0);
                }
                else
                {
                    if (item.gameObject.CompareTag("fire"))
                    {
                        StartCoroutine(SetFire());
                        break;
                    }
                }
            }

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collList.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collList.Remove(collision);
    }


    IEnumerator SetFire()
    {
        yield return new WaitForSeconds(0.1f);
        tag = "fire";
        body.bodyType = RigidbodyType2D.Dynamic;

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
