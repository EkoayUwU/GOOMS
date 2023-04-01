using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rb; // référence au Rigidbody2D du joueur
    private PlayerMovement movementScript; // référence au script PlayerMovement attaché au joueur
    private BoxCollider2D boxCollider; // référence au BoxCollider2D attaché au joueur
    private CapsuleCollider2D capCollider; // référence au CapsuleCollider2D attaché au joueur
    private SpriteRenderer sr; // référence au SpriteRenderer attaché au joueur

    private int healthPoint; // point de santé du joueur

    void Start()
    {
        healthPoint = 1; // initialisation du point de santé du joueur
        rb = GetComponent<Rigidbody2D>(); // récupération du Rigidbody2D attaché au joueur
        movementScript = GetComponent<PlayerMovement>(); // récupération du script PlayerMovement attaché au joueur
        sr = GetComponent<SpriteRenderer>(); // récupération du SpriteRenderer attaché au joueur

        boxCollider = rb.GetComponent<BoxCollider2D>(); // récupération du BoxCollider2D attaché au Rigidbody2D
        capCollider = rb.GetComponent<CapsuleCollider2D>(); // récupération du CapsuleCollider2D attaché au Rigidbody2D
    }

    void Update()
    {
        if (healthPoint <= 0) // si la santé du joueur est inférieure ou égale à 0
        {
            // désactiver le mouvement, changer la couleur du SpriteRenderer, désactiver le CapsuleCollider2D et changer le layer du gameObject
            movementScript.enabled = false;
            sr.color = new Color(255f, 0f, 0f);
            capCollider.enabled = false;
            gameObject.layer = 7;

            if (Input.GetKeyDown(KeyCode.Return)) // si la touche Entrée est enfoncée
            {
                // réinitialiser la santé, réactiver le mouvement, changer la couleur du SpriteRenderer, réactiver le CapsuleCollider2D et changer le layer du gameObject
                //healthPoint = 1;
                //movementScript.enabled = true;
                //sr.color = new Color(255f, 255f, 255f);
                //capCollider.enabled = true;
                //gameObject.layer = 8;
            }

            /* Lancement Animation + Ecran Mort
               Juuuuuuuuste ici
               Là
            */
        }

        if (Input.GetKeyDown(KeyCode.H)) // si la touche H est enfoncée
        {
            Damage(1); // infliger des dégâts au joueur
        }
    }

    public void SetHealth(int health) // méthode publique pour définir la santé du joueur
    {
        healthPoint = health;
    }

    public void Damage(int dmg) // méthode publique pour infliger des dégâts au joueur
    {
        healthPoint -= dmg;
    }
}