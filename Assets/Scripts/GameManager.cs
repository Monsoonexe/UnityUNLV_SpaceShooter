using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : RichMonoBehaviour
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
