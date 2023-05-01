using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;

public class batMouvement : MonoBehaviour
{
    [SerializeField] GameObject PlayerRef;

    Vector3 playerPosition;
    int playerDirection  = 0;

    bool isAttacking = false;
    Vector3 batPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            StartCoroutine(playerOffset());
            playerPosition = collision.transform.position;
            Attacking();
            Debug.Log("Oui");
            playerDirection = (int)collision.transform.localScale.x;
            Debug.Log("Direction " + playerDirection);
        }
    }

    #region Player Offset
    IEnumerator playerOffset()
    {
        yield return new WaitForSeconds(1f);
        Vector3 coord1 = PlayerRef.transform.position;
        yield return new WaitForSeconds(1f);
        Vector3 coord2 = PlayerRef.transform.position;

        Debug.Log("Coord1 " + coord1 + " Coord2 " + coord2);
    }
    #endregion

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            //transform.position = new Vector2(transform.position.x, Mathf.Lerp(7.76f, 3, 1));
            batPosition = transform.position;
            transform.position += QuadraticLerp(batPosition, playerPosition, 5f);
            
        }
        if (isAttacking)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, playerPosition.x, 1f) + playerDirection * 5f, Mathf.Lerp(transform.position.y, playerPosition.y, 1f));
        }

    }

    void Attacking()
    {
        isAttacking = true;   
    }

    Vector3 QuadraticLerp (Vector3 bat, Vector3 player, float offset)
    {
        Vector3 ab = Vector3.Lerp(bat, player, 1);
        Vector3 bc = Vector3.Lerp(player, player + (new Vector3(offset, 0, 0)), 1);
        return Vector3.Lerp(ab,bc, 1);
    }
}

