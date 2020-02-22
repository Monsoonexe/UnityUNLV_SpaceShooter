using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
       
    public void QuitGame()
    {
        Application.Quit();

        EditorApplication.isPlaying = false;
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
