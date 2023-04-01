using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    // Booléen qui indique si le joueur est sur la plateforme
    private bool OnPlatform = false;

    // Tableau de points de passage de la plateforme
    [SerializeField] Transform[] Waypoints;

    // Point de passage actuel de la plateforme
    private Transform target;

    // Index du point de passage actuel de la plateforme
    private int indexPoint = 0;

    // Vitesse de déplacement de la plateforme
    private float speed = 3f;

    // Fonction exécutée au lancement du jeu
    private void Start()
    {
        // Initialisation du point de passage actuel de la plateforme
        target = Waypoints[0];
    }

    // Fonction exécutée à chaque frame
    private void FixedUpdate()
    {
        // Calcul de la direction vers le point de passage actuel de la plateforme
        Vector3 direction = target.position - transform.position;

        // Fonction de déplacement de la plateforme
        void PlatformDeplacment(GameObject gameObject)
        {
            // Déplacement de la plateforme dans la direction calculée
            gameObject.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

        // Déplacement de la plateforme
        PlatformDeplacment(gameObject);

        // Si la plateforme atteint le point de passage actuel
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            // Passage au point de passage suivant
            indexPoint++;
            target = Waypoints[indexPoint % Waypoints.Length];
        }

        // Si le joueur est sur la plateforme
        if (OnPlatform)
        {
            // Déplacement du joueur avec la plateforme
            PlatformDeplacment(playerRef);
        }
    }

    // Fonction exécutée lorsqu'un objet entre en collision avec la plateforme
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si l'objet est le joueur
        if (collision.name == "Player")
        {
            // Le joueur est sur la plateforme
            OnPlatform = true;
        }
    }

    // Fonction exécutée lorsqu'un objet sort de la collision avec la plateforme
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si l'objet est le joueur
        if (collision.name == "Player")
        {
            // Le joueur n'est plus sur la plateforme
            OnPlatform = false;
        }
    }

    // Fonction qui retourne si le joueur est sur la plateforme
    public bool Get()
    {
        return OnPlatform;
    }
}
