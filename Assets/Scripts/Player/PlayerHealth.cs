using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb; // r�f�rence au Rigidbody2D du joueur
    private PlayerMovement movementScript; // r�f�rence au script PlayerMovement attach� au joueur
    private BoxCollider2D boxCollider; // r�f�rence au BoxCollider2D attach� au joueur
    private CapsuleCollider2D capCollider; // r�f�rence au CapsuleCollider2D attach� au joueur
    private SpriteRenderer sr; // r�f�rence au SpriteRenderer attach� au joueur

    private int healthPoint; // point de sant� du joueur

    void Start()
    {
        healthPoint = 1; // initialisation du point de sant� du joueur
        rb = GetComponent<Rigidbody2D>(); // r�cup�ration du Rigidbody2D attach� au joueur
        movementScript = GetComponent<PlayerMovement>(); // r�cup�ration du script PlayerMovement attach� au joueur
        sr = GetComponent<SpriteRenderer>(); // r�cup�ration du SpriteRenderer attach� au joueur

        boxCollider = rb.GetComponent<BoxCollider2D>(); // r�cup�ration du BoxCollider2D attach� au Rigidbody2D
        capCollider = rb.GetComponent<CapsuleCollider2D>(); // r�cup�ration du CapsuleCollider2D attach� au Rigidbody2D
    }

    void Update()
    {
        if (healthPoint <= 0) // si la sant� du joueur est inf�rieure ou �gale � 0
        {
            // d�sactiver le mouvement, changer la couleur du SpriteRenderer, d�sactiver le CapsuleCollider2D et changer le layer du gameObject
            movementScript.enabled = false;
            sr.color = new Color(255f, 0f, 0f);
            capCollider.enabled = false;
            gameObject.layer = 7;

            if (Input.GetKeyDown(KeyCode.Return)) // si la touche Entr�e est enfonc�e
            {
                // r�initialiser la sant�, r�activer le mouvement, changer la couleur du SpriteRenderer, r�activer le CapsuleCollider2D et changer le layer du gameObject
                //healthPoint = 1;
                //movementScript.enabled = true;
                //sr.color = new Color(255f, 255f, 255f);
                //capCollider.enabled = true;
                //gameObject.layer = 8;
            }

            /* Lancement Animation + Ecran Mort
               Juuuuuuuuste ici
               L�
            */
        }

        if (Input.GetKeyDown(KeyCode.H)) // si la touche H est enfonc�e
        {
            Damage(1); // infliger des d�g�ts au joueur
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