using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossManager : MonoBehaviour
{
    [SerializeField] GameObject CameraTravelingRefPoint;
    GameObject PlayerRef;

    bool isTravelling = false;
    bool Wait1 = false;

    private void Start()
    {
        PlayerRef = GameObject.Find("Player");
    }


    private void Update()
    {
        if (isTravelling && Wait1)
        {
            if ( CameraTravelingRefPoint.transform.position.y < 65.0f)
            {
                CameraTravelingRefPoint.transform.position += new Vector3(0, Time.deltaTime, 0) * 25f;
            }
            else isTravelling = false;        
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerRef.GetComponent<Player_Movement>().enabled = false;
        PlayerRef.GetComponent<Animator>().SetFloat("Speed", 0);
        PlayerRef.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        GetComponent<BoxCollider2D>().enabled = false;

        isTravelling = true;

        StartCoroutine(Timer1());
    }

    IEnumerator Timer1()
    {
        yield return new WaitForSeconds(2.5f);
        Wait1 = true;

        if(GameObject.Find("NoY_To_Travelling") != null) Destroy(GameObject.Find("NoY_To_Travelling"));

    }
}
