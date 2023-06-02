using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class BackgroundAnimation : MonoBehaviour
{

    [SerializeField] GameObject CharaRef;
    Animator CharaAnim;
    SpriteRenderer CharaRenderer;

    [SerializeField] Transform WaypointSpawnLeft;
    [SerializeField] Transform WaypointEndLeft;

    [SerializeField] Transform WaypointSpawnRight;
    [SerializeField] Transform WaypointEndRight;

    bool boolStep1 = false;
    bool boolStep2 = false;
    bool boolStep3 = false;
    bool boolStep4 = false;

    private void Start()
    {

        CharaAnim = CharaRef.GetComponent<Animator>();
        CharaRenderer = CharaRef.GetComponent<SpriteRenderer>();

        Step1();
    }

    private void Update()
    {
        if (boolStep1)
        {
            CharaRef.transform.position = Vector3.MoveTowards(CharaRef.transform.position, WaypointEndLeft.position, 0.004f);

            if(CharaRef.transform.position.x == WaypointEndLeft.position.x)
            {
                boolStep1 = false;
                CharaAnim.SetFloat("Speed", 0f);
                Invoke("Step2", 3.75f);
            }
        }

        if (boolStep2)
        {
            CharaRef.transform.position = Vector3.MoveTowards(CharaRef.transform.position, WaypointSpawnLeft.position, 0.004f);

            if (CharaRef.transform.position.x == WaypointSpawnLeft.position.x)
            {
                boolStep2 = false;
                Invoke("Step3", 5f);
            }
        }

        if (boolStep3)
        {
            CharaRef.transform.position = Vector3.MoveTowards(CharaRef.transform.position, WaypointEndRight.position, 0.004f);

            if (CharaRef.transform.position.x == WaypointEndRight.position.x)
            {
                boolStep3 = false;
                CharaAnim.SetFloat("Speed", 0f);
                Invoke("Step4", 3.75f);
            }
        }

        if (boolStep4)
        {
            CharaRef.transform.position = Vector3.MoveTowards(CharaRef.transform.position, WaypointSpawnRight.position, 0.004f);

            if (CharaRef.transform.position.x == WaypointSpawnRight.position.x)
            {
                boolStep4 = false;
                Invoke("Step1", 5f);
            }
        }
    }

    void Step1()
    {
        CharaRef.transform.position = new Vector2(WaypointSpawnLeft.position.x, CharaRef.transform.position.y);
        CharaAnim.SetFloat("Speed", 5f);

        boolStep1 = true;
    }

    void Step2()
    {
        CharaRenderer.flipX = true;
        CharaAnim.SetFloat("Speed", 5f);

        boolStep2 = true;
    }

    void Step3()
    {
        CharaRef.transform.position = new Vector2(WaypointSpawnRight.position.x, CharaRef.transform.position.y);   

        boolStep3 = true;
    }

    void Step4()
    {
        CharaRenderer.flipX = false;
        CharaAnim.SetFloat("Speed", 5f);

        boolStep4 = true;
    }
}
