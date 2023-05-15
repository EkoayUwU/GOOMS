// Importation des modules n�cessaires
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using Unity.VisualScripting;
using UnityEngine;

// D�claration de la classe EnnemyMovement qui h�rite de MonoBehaviour
public class EnnemyMovement : MonoBehaviour
{
    // R�f�rence au joueur, la zone de d�tection et la plateforme mobile
    [SerializeField] GameObject playerRef;
    [SerializeField] ZoneDetection zoneRef;
    [SerializeField] MovingPlatform platformRef;

    // R�f�rence au Rigidbody2D de l'ennemi
    Rigidbody2D rb;

    // Les points de passages que l'ennemi doit suivre
    [SerializeField] Transform[] waypoints;
    private int indexWaypoints = 0;
    private Transform target;
    private int direction = 0;
    private Vector2 directionTarget;


    Vector2 target_velocity;
    [SerializeField] float movementSpeed = 550f;
    Vector2 ref_velocity = Vector2.zero;

    bool aggroTaken = false;



    // Start est appel� avant la premi�re frame update
    void Start()
    {
        // Initialisation de la premi�re cible de d�placement
        target = waypoints[0];

        // R�cup�ration du Rigidbody2D de l'ennemi
        rb = GetComponent<Rigidbody2D>();
    }


    // Update est appel� une fois par frame
    void Update() 
    {
        // Si la zone de d�tection est d�sactiv�e, l'ennemi ne poursuit plus le joueur
        if (zoneRef.Get() == false)
        {
            aggroTaken = false;
        }

        // V�rification si le joueur est � gauche de l'ennemi
        bool CheckGauche()
        {
            return (((transform.position.x >= playerRef.transform.position.x) && (transform.localScale.x == -1) && (zoneRef.Get()))) ? true : false;
        }

        // V�rification si le joueur est � droite de l'ennemi
        bool CheckDroite()
        {
            return (((transform.position.x <= playerRef.transform.position.x) && (transform.localScale.x == 1) && (zoneRef.Get()))) ? true : false;
        }

        // V�rification si l'ennemi doit poursuivre le joueur
        bool Aggro()
        {
            return ((CheckGauche() || CheckDroite()) && !platformRef.Get()) ? true : false;
        }


        if (Aggro())
        {
            // Si l'ennemi poursuit le joueur, il devient plus rapide
            aggroTaken = true;
            movementSpeed = 800f;

            // D�termination de la direction � suivre pour atteindre le joueur
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;
        }
        else
        {
            // Si l'ennemi ne poursuit pas le joueur, il suit les points de passage
            movementSpeed = 550f;
            target = waypoints[indexWaypoints % waypoints.Length];
            directionTarget = target.position - gameObject.transform.position;
            direction = directionTarget.x > 0 ? 1 : -1;

            // Changement de direction si l'ennemi atteint un point de passage
            if (Vector2.Distance(transform.position, target.position) < 1.25f)
            {
                indexWaypoints++;
                rb.velocity = direction == 1 ? new Vector2(2f, 0) : new Vector2(-2f, 0);
                target = waypoints[indexWaypoints % waypoints.Length];
            }
            SwapSens();
        }


        if (aggroTaken && zoneRef.Get() && !Aggro())
        {           
            target = playerRef.transform;
            SwapSens();
            aggroTaken = false;
        }

        Debug.Log("Target : " + target);

    }

    private void FixedUpdate()
    {
            target_velocity = new Vector2(direction * movementSpeed * Time.deltaTime, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.5f);       
    }
    private void SwapSens()
    {
        transform.localScale = target.position.x > transform.position.x ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
    }

}
