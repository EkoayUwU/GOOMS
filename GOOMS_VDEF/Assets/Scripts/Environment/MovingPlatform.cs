using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    private bool OnPlatform = false;

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
