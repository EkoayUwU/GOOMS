using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb; // r�f�rence au Rigidbody2D du joueur
    private Player_Movement movementScript; // r�f�rence au script PlayerMovement attach� au joueur
    private Player_Jump jumpScript;
    private BoxCollider2D boxCollider; // r�f�rence au BoxCollider2D attach� au joueur
    private CapsuleCollider2D capCollider; // r�f�rence au CapsuleCollider2D attach� au joueur
    private SpriteRenderer sr; // r�f�rence au SpriteRenderer attach� au joueur

    private int healthPoint; // point de sant� du joueur

    void Start()
    {
        healthPoint = 1; // initialisation du point de sant� du joueur
        rb = GetComponent<Rigidbody2D>(); // r�cup�ration du Rigidbody2D attach� au joueur
        movementScript = GetComponent<Player_Movement>(); // r�cup�ration du script Player_Movement attach� au joueur
        jumpScript= GetComponent<Player_Jump>(); // r�cup script Player_Jump
        sr = GetComponent<SpriteRenderer>(); // r�cup�ration du SpriteRenderer attach� au joueur

        boxCollider = rb.GetComponent<BoxCollider2D>(); // r�cup�ration du BoxCollider2D attach� au Rigidbody2D
        capCollider = rb.GetComponent<CapsuleCollider2D>(); // r�cup�ration du CapsuleCollider2D attach� au Rigidbody2D
    }

    void Update()
    {
        if (healthPoint <= 0) // si la sant� du joueur est inf�rieure ou �gale � 0
        {
            // d�sactiver le mouvement, changer la couleur du SpriteRenderer, d�sactiver le CapsuleCollider2D et changer le layer du gameObject
            //rb.velocity = new Vector2(5, -15);

            rb.bodyType = RigidbodyType2D.Static;
            movementScript.enabled = false;
            jumpScript.enabled = false;
            GameObject.Find("Cursor").GetComponent<DragAndDrop>().enabled = false;
            GameObject.Find("Cursor").GetComponent<CursorPosition>().enabled = false;
            
            sr.color = new Color(255f, 0f, 0f);
            boxCollider.enabled = false;
            capCollider.enabled = false;
            gameObject.layer = 7;

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Jump")) // si la touche Entr�e est enfonc�e
            {
                GetComponent<spawnManager>().ReloadSceneOnDeath();
            }
        }
    }

    public void SetHealth(int health) // m�thode publique pour d�finir la sant� du joueur
    {
        healthPoint = health;
    }

    public void Damage(int dmg) // m�thode publique pour infliger des d�g�ts au joueur
    {
        healthPoint -= dmg;
    }
}