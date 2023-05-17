using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_BAT : MonoBehaviour
{
    bool isIn;
    [SerializeField] bool isChasing;
    [SerializeField] bool isDone = true;

    [SerializeField] Vector3 BatPos;
    [SerializeField] Vector3 SymBatPos;
    [SerializeField] Vector3 PlayerPos;
    [SerializeField] Vector3 SymPlayerPos;
    [SerializeField] Vector3 OffsetPotentialPlayerPos;
    Vector3 OffsetPlayerHeight;
    float InterpolateTime;

    [SerializeField] Vector3 BatToPlayer;
    [SerializeField] Vector3 PlayerToPotPlayer;

    
    private void Start()
    {
        OffsetPotentialPlayerPos = new Vector3(5f, 0, 0);
        OffsetPlayerHeight = new Vector3(0, 2.5f, 0);
    }
    private void Update()
    {
        //if(!isDone) InterpolateTime = (InterpolateTime + Time.deltaTime) % 1f;
        InterpolateTime = isDone ? 0 : (InterpolateTime + Time.deltaTime) % 1f;


        //cast raycast down pour détecter 1er élément rencontré
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 1.6f, 0), Vector2.down, 10f);
        Debug.DrawRay(transform.position - new Vector3(0, 1.6f, 0), Vector2.down * 10f, Color.red);

        // si hit collider
        if (hit.collider.name != null)
        {
            if (hit.collider.name == "Player" && isDone)
            {
                isDone = false;
                if(hit.transform.localScale.x == 1) InitChaseRight(hit.transform);
                if(hit.transform.localScale.x == -1) InitChaseLeft(hit.transform);

            }
        }

        if (Vector3.Distance(transform.position, SymBatPos) < 1f)
        {
            isChasing = false;
            isDone = true;
        }

        if (isChasing && InterpolateTime < 1f) 
            transform.position = CubicLerp(BatPos, PlayerPos, SymPlayerPos, SymBatPos, InterpolateTime);
    }

    void FixedUpdate()
    {        
        
    }


    void InitChaseRight(Transform playerTransform)
    {    
        BatPos = transform.position + new Vector3(0, 1, 0);
        SymBatPos = BatPos + OffsetPotentialPlayerPos * 2;
        PlayerPos = new Vector3(playerTransform.position.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        SymPlayerPos = PlayerPos + OffsetPotentialPlayerPos * 2;
        isChasing = true;
    }

    void InitChaseLeft(Transform playerTransform)
    {
        BatPos = transform.position + new Vector3(0, 1, 0);
        SymBatPos = BatPos - OffsetPotentialPlayerPos * 2;
        PlayerPos = new Vector3(playerTransform.position.x, playerTransform.position.y - OffsetPlayerHeight.y, 0);
        SymPlayerPos = PlayerPos - OffsetPotentialPlayerPos * 2;
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
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log(collision.gameObject.name);
            isChasing = false;
        }
    }
}
