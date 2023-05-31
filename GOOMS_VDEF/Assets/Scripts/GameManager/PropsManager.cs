using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{

    [SerializeField] GameObject[] PropsList;
    Vector3[] PropsSpawnPos;


    private void Start()
    {

        PropsSpawnPos = new Vector3[PropsList.Length]; 
        for (int i = 0; i < PropsList.Length; i++)
        {
            PropsSpawnPos[i] = PropsList[i].transform.position;

            //Debug.Log(PropsList[i] + " " +  PropsSpawnPos[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int i = 0; i < PropsList.Length; i++)
        {
            if (collision.gameObject.name == PropsList[i].name)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; 
                collision.gameObject.transform.position = PropsSpawnPos[i];
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        //Debug.Log(collision.gameObject.transform.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < PropsList.Length; i++)
        {
            if (collision.gameObject.name == PropsList[i].name)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.transform.position = PropsSpawnPos[i];
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        //Debug.Log(collision.gameObject.transform.name);
    }
}
