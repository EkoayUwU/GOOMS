using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    [SerializeField] string SceneName;
    [SerializeField] spawnManager SpawnManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Reset pos player + Load Sc�ne suivante
            SpawnManager.SetSpawnPosition(Vector2.zero);
            SceneManager.LoadScene(SceneName);

            //Reset le tab de checkpoint lors du changement de sc�ne
            GameObject.Find("GAMEMANAGER").GetComponent<CheckPointManager>().ResetCheckPointTab();
        }
    }
}
