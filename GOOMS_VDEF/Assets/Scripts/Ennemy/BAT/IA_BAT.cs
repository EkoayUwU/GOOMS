using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class IA_BAT : MonoBehaviour
{
    bool isIn;
    [SerializeField] bool isChasing;
    [SerializeField] bool isDone = true;
    [SerializeField] bool onCD = false;

    [SerializeField] Vector3 BatPos;
    [SerializeField] Vector3 BatLandingPos;
    [SerializeField] Vector3 PlayerPos;
    [SerializeField] Vector3 PotentialPlayerPosExt;
    [SerializeField] Vector3 PotentialPlayerPosInt;
    [SerializeField] Vector3 OffsetPotentialPlayerPos;
    Vector3 OffsetPlayerHeight;
    float InterpolateTime;

    [SerializeField] Vector3 BatToPlayer;
    [SerializeField] Vector3 PlayerToPotPlayer;

    //Debug
    //[SerializeField] GameObject pointBatOrigin;
    //[SerializeField] GameObject pointBatLanding;
    //[SerializeField] GameObject pointPlayerExt;
    //[SerializeField] GameObject pointPlayerInt;

    private void Start()
    {
        onCD = false;
        OffsetPotentialPlayerPos = new Vector3(5f, 0, 0);
        OffsetPlayerHeight = new Vector3(0, 3f, 0);
    }
    private void Update()
    {
        InterpolateTime = isDone ? 0 : (InterpolateTime + Time.deltaTime) % 1f;

        //Debug
        //pointBatOrigin.transform.position = BatPos;
        //pointBatLanding.transform.position = BatLandingPos;
        //pointPlayerExt.transform.position = PotentialPlayerPosExt;
        //pointPlayerInt.transform.position = PotentialPlayerPosInt;



        //cast raycast down pour détecter 1er élément rencontré
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - new Vector3(0, 1.15f, 0), Vector2.down + Vector2.left, 15f);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position - new Vector3(0, 1.15f, 0), Vector2.down + Vector2.right, 15f);

        Debug.DrawRay(transform.position - new Vector3(0, 1.15f, 0), (Vector2.down + Vector2.left) * 15f, Color.red);
        Debug.DrawRay(transform.position - new Vector3(0, 1.15f, 0), (Vector2.down + Vector2.right) * 15f, Color.red);

        Debug.Log(hitLeft.collider.name);

        Debug.Log(hitRight.collider.name);
        // si hit collider
        if (hitLeft)
        {
            //Debug.Log(hitLeft.collider.gameObject.layer);
            if (hitLeft.collider.name == "Player" && isDone && !onCD)
            {
                isDone = false;
                InitChaseLeft(hitLeft.transform);

            }
        }
        if (hitRight)
        {
            //Debug.Log(hitRight.collider.gameObject.layer);
            if (hitRight.collider.name == "Player" && isDone && !onCD)
            {
                isDone = false;
                InitChaseRight(hitRight.transform);
            }
        }


    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(BatLandingPos.x, 0, 0)) <= 0.5f && Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, BatLandingPos.y, 0)) <= 0.5f && isChasing)
        {
            isChasing = false;
            isDone = true;
            StartCoroutine(CD());
        }

        if (isChasing && InterpolateTime < 1f)

            transform.position = CubicLerp(BatPos, PotentialPlayerPosInt, PotentialPlayerPosExt, BatLandingPos, InterpolateTime);
    }

    void InitChaseRight(Transform playerTransform)
    {
        BatPos = transform.position;
        BatLandingPos = BatPos + new Vector3(Vector3.Distance(new Vector3(BatPos.x, 0, 0), new Vector3(playerTransform.position.x, 0, 0)), 0, 0) * 2;
        PotentialPlayerPosExt = new Vector3(playerTransform.position.x + OffsetPotentialPlayerPos.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        PotentialPlayerPosInt = new Vector3(playerTransform.position.x - OffsetPotentialPlayerPos.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        isChasing = true;
    }

    void InitChaseLeft(Transform playerTransform)
    {
        BatPos = transform.position;
        BatLandingPos = BatPos - new Vector3(Vector3.Distance(new Vector3(BatPos.x, 0, 0), new Vector3(playerTransform.position.x, 0, 0)), 0, 0) * 2;
        PotentialPlayerPosExt = new Vector3(playerTransform.position.x - OffsetPotentialPlayerPos.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        PotentialPlayerPosInt = new Vector3(playerTransform.position.x + OffsetPotentialPlayerPos.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        isChasing = true;
    }

    Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, InterpolateTime);
    }

    Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, InterpolateTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Roof")
        {
            Debug.Log("HIT " + collision.gameObject.name);

            if (isChasing)
            {
                isChasing = false;
                isDone = true;
                StartCoroutine(CD());
            }

        }

        if (collision.name == "Player")
        {
            Debug.Log("Player was hit");
        }

    }

    IEnumerator CD()
    {
        onCD = true;
        yield return new WaitForSeconds(1.25f);
        onCD = false;
    }
}