using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBossManager : MonoBehaviour
{
    GameObject PlayerRef;
    GameObject CursorRef;

    [SerializeField] GameObject bossRef;

    bool isRunning = false;
    [SerializeField] bool ForceAnim = false;
    private void Start()
    {
        PlayerRef = GameObject.Find("Player");
        CursorRef = GameObject.Find("Cursor");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerRef.GetComponent<Player_Movement>().enabled = false;
        PlayerRef.GetComponent<Animator>().SetFloat("Speed", 0);
        PlayerRef.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        CursorRef.GetComponent<SpriteRenderer>().enabled = false;

        GetComponent<BoxCollider2D>().enabled = false;

        Invoke(nameof(StopAnimBoss), 1.5f);
    }

    private void Update()
    {
        if (ForceAnim)
        {
            ForceAnim = false;
            Invoke(nameof(StopAnimBoss), 1.5f);
        }
        
        if(isRunning) bossRef.transform.position += new Vector3(0.4f, 0, 0);
    }
    void StopAnimBoss()
    {
        bossRef.GetComponent<Animator>().enabled = false;
        
        Invoke(nameof(FlipBoss), 1.25f);
    }

    void FlipBoss()
    {
        bossRef.GetComponent<SpriteRenderer>().flipX = true;
        Invoke(nameof(RunAnimBoss), 0.75f);
    }

    void RunAnimBoss()
    {
        //Start Anim Panique + Course
        Invoke(nameof(RunBoss), 0.5f);
    }

    void RunBoss()
    {
        bossRef.GetComponent<SpriteRenderer>().flipX = false;
        bossRef.GetComponent<Animator>().enabled = true;
        isRunning = true;

        Invoke("Credits", 4f);
    }

    void Credits()
    {
        SceneManager.LoadScene("CREDITS");
    }


}
