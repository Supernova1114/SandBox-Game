using System.Collections;
using UnityEngine;

public class countDownHandler : MonoBehaviour
{

    public SpriteRenderer rendererr;
    public ArrayList inRadius = new ArrayList();
    private ArrayList temp;

    // Start is called before the first frame update
    void Start()
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

        foreach (GameObject obj in temp)
        {
            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));

        }

        StartCoroutine(Bleh());

        /*foreach (GameObject obj in temp)
        {
            Destroy(obj, 0f);
        }*/

        //Destroy(this.gameObject, 0);
    }

    IEnumerator Bleh()
    {
        /*yield return new WaitForSeconds(2f);

        foreach (GameObject obj in temp)
        {
            Destroy(obj, 0f);
        }
        */
        yield return new WaitForSeconds(0f);
        Destroy(this.gameObject, 0);

    }
}
