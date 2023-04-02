using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] spawnManager spawnManager;
    [SerializeField] Sprite greenFlag;

    [SerializeField] CheckPointManager CheckPointManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Set les pos de spawn du joueur selon le checkpoint et modifie l�tat du checkpoint dans le tableau 
            spawnManager.SetSpawnPosition(transform.position);
            CheckPointManager.SetCheckPoint(gameObject.name);
        }
    }

    private void Update()
    {
        //D�sactive tous les checkpoints se trouvant avant le dernier checkpoint activ�
        if (CheckPointManager.GetCheckPointState(gameObject.name))
        {
            GetComponent<SpriteRenderer>().sprite = greenFlag;
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
