using System.Collections;
using UnityEngine;

public class countDownHandler : MonoBehaviour
{

    public SpriteRenderer rendererr;
    public ArrayList inRadius = new ArrayList();
    private ArrayList temp;

    public GameObject guyBoom;
    public GameObject badguyBoom;

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(StartCountDown());
    }

    IEnumerator StartCountDown()
    {
        

        for (int i=0; i<6; i++)
        {
            yield return new WaitForSeconds(0.2f);
            rendererr.color = Color.grey;
            yield return new WaitForSeconds(0.2f);
            rendererr.color = Color.white;
        }

        temp = (ArrayList)(inRadius.Clone());

        /*foreach (GameObject obj in temp)
        {
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));

        }*/

        StartCoroutine(Bleh());

        /*foreach (GameObject obj in temp)
        {
            Destroy(obj, 0f);
        }*/

        //Destroy(this.gameObject, 0);
    }

    //GameObject t;
    IEnumerator Bleh()
    {
        //yield return new WaitForSeconds(2f);

        foreach (GameObject obj in temp)
        {
            if ( !obj.CompareTag("guy") )
            {
                Destroy(obj, 0f);
            }
            else
            {
                StartCoroutine(HandleGuy(obj));
            }
            
        }

        yield return new WaitForSeconds(0f);
        Destroy(this.gameObject, 0);

    }

    IEnumerator HandleGuy(GameObject obj)
    {
        GameObject temp = obj;
        Destroy(obj, 0f);

        GameObject guyBoomObj = Instantiate(guyBoom, temp.transform.position, temp.transform.rotation);

        Vector2 rel = (Vector2)(temp.transform.position - transform.position).normalized;
        guyBoomObj.GetComponent<guyExploder>().SendForce(rel);

        yield return new WaitForSeconds(0);
    }



}
