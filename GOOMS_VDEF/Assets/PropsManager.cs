using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{

    [SerializeField] GameObject[] PropsList;
    Vector3[] PropsSpawnPos;

    PlayerHealth PlayerHealth;


    private void Start()
    {

        PropsSpawnPos = new Vector3[PropsList.Length]; 
        for (int i = 0; i < PropsList.Length; i++)
        {
            PropsSpawnPos[i] = PropsList[i].transform.position;

            //Debug.Log(PropsList[i] + " " +  PropsSpawnPos[i]);
        }

        PlayerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") PlayerHealth.Damage(100);

        for (int i = 0; i < PropsList.Length; i++)
        {
            if (collision.gameObject.name == PropsList[i].name)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collision.gameObject.transform.position = PropsSpawnPos[i];
            }
        }
        //Debug.Log(collision.gameObject.transform.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") PlayerHealth.Damage(100);

        for (int i = 0; i < PropsList.Length; i++)
        {
            if (collision.gameObject.name == PropsList[i].name)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collision.gameObject.transform.position = PropsSpawnPos[i];
            }
        }
        //Debug.Log(collision.gameObject.transform.name);
    }
}
