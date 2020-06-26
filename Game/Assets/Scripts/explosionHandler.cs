using UnityEngine;

public class explosionHandler : MonoBehaviour
{

    public GameObject charge;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            if (!(collision.gameObject.GetComponent<countDownHandler>().inRadius.Contains(gameObject)))
            {
                collision.gameObject.GetComponent<countDownHandler>().inRadius.Add(gameObject);
            }
        }

    } 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "charge")
        {
            if (collision.gameObject.GetComponent<countDownHandler>().inRadius.Contains(gameObject))
            {
                collision.gameObject.GetComponent<countDownHandler>().inRadius.Remove(gameObject);
            }
        }
    }


}
