using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartBossManager : MonoBehaviour
{
    [SerializeField] GameObject CameraTravelingRefPoint;
    GameObject PlayerRef;
    GameObject CursorRef;

    [SerializeField] CinemachineVirtualCamera FocusedCamera01;
    CameraManager cmRef;

    bool isTravelling = false;
    bool Wait1 = false;

    bool start2ndStep = false;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject valveRef;
    [SerializeField] GameObject flotteRef;
    bool isRotating = false;

    bool start3rdStep = false;
    [SerializeField] CinemachineVirtualCamera TravelingCamera;
    [SerializeField] GameObject TriggerNoY;

    private void Start()
    {
        PlayerRef = GameObject.Find("Player");
        CursorRef = GameObject.Find("Cursor");
        cmRef = GameObject.Find("Cameras").GetComponent<CameraManager>();
    }


    private void Update()
    {
        if (isTravelling && Wait1)
        {
            if ( CameraTravelingRefPoint.transform.position.y < 65.0f)
            {
                CameraTravelingRefPoint.transform.position += new Vector3(0, Time.deltaTime, 0) * 25f;
            }
            else
            {
                isTravelling = false;
                start2ndStep = true;
            }
                      
        }
        
        if(start2ndStep)
        {
            start2ndStep = false;
            Invoke(nameof(SecondEtape), 1.0f);
        }

        if (isRotating) valveRef.transform.Rotate(0, 0, 7.5f);

        if (start3rdStep)
        {
            CameraTravelingRefPoint.transform.position = new Vector2(CameraTravelingRefPoint.transform.position.x, PlayerRef.transform.position.y + 3f);
        }
    }

    #region 1ère Etape
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerRef.GetComponent<Player_Movement>().enabled = false;
        PlayerRef.GetComponent<Animator>().SetFloat("Speed", 0);
        PlayerRef.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        CursorRef.GetComponent<CursorPosition>().enabled = false;

        GetComponent<BoxCollider2D>().enabled = false;

        isTravelling = true;

        StartCoroutine(Timer1());
    }

    IEnumerator Timer1()
    {
        yield return new WaitForSeconds(1.75f);
        Wait1 = true;

        if(GameObject.Find("NoY_To_Travelling") != null) Destroy(GameObject.Find("NoY_To_Travelling"));
        
    }

    #endregion

    #region 2nd Etape

    void SecondEtape()
    {
        cmRef._CurrentCamera.enabled = false;
        cmRef._CurrentCamera = FocusedCamera01;
        cmRef._CurrentCamera.enabled = true;

        Invoke(nameof(AnimBoss), 2.5f);
    }

    void AnimBoss()
    {
        Boss.GetComponent<SpriteRenderer>().flipX = false;
        StartCoroutine(TimerValve());
    }

    IEnumerator TimerValve()
    {
        yield return new WaitForSeconds(0.77f);
        isRotating = true;
        yield return new WaitForSeconds(0.80f);
        isRotating = false;
        flotteRef.SetActive(true);

        Invoke(nameof(ThirdStep), 1f);
    }
    #endregion

    #region 3ème Etape

    void ThirdStep()
    {
        start3rdStep = true;

        cmRef._CurrentCamera.enabled = false;
        cmRef._CurrentCamera = TravelingCamera;
        cmRef._CurrentCamera.enabled = true;

        PlayerRef.GetComponent<Player_Jump>().enabled = true;
        PlayerRef.GetComponent<Player_Movement>().enabled = true;
        TriggerNoY.GetComponent<BoxCollider2D>().enabled = true;

        CursorRef.GetComponent<CursorPosition>().enabled = true;
    }
    #endregion
}
