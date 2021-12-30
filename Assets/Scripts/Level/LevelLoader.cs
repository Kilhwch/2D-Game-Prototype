using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public int iLevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            LoadScene();
    }


    void LoadScene()
    {
        SceneManager.LoadScene(iLevelToLoad);
    }
}
