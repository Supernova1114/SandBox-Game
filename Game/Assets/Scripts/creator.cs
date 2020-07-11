using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creator : MonoBehaviour
{
    private GameObject chosen;

    public GameObject dirt;
    public GameObject water;
    public GameObject rock;
    public GameObject charge;
    public GameObject acid;
    public GameObject guy;

    private bool flag = true;


    Vector3 pos;
    GameObject clone;
    void Start()
    {
        chosen = dirt;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            chosen = dirt;
        }

        if ( Input.GetKeyDown( KeyCode.Alpha2 ))
        {
            chosen = rock;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            chosen = water;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            chosen = acid;
        }

        if ( Input.GetKeyDown(KeyCode.Alpha5))
        {
            chosen = charge;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            chosen = guy;
        }


        if ( Input.GetMouseButton(0) )
        {
            pos = Camera.main.ScreenToWorldPoint( Input.mousePosition + new Vector3(0, 0, 9) );

            if (chosen != charge && chosen != guy)
            {
                clone = Instantiate(chosen, pos, transform.rotation);
            }
            else
            {
                if (flag == true)
                {
                    flag = false;
                    StartCoroutine(PlaceCharge());
                }
            }

        }
    }

    IEnumerator PlaceCharge()
    {
        clone = Instantiate(chosen, pos, transform.rotation);

        yield return new WaitForSeconds(0.1f);

        flag = true;
    }



}
