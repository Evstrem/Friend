using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра закрыта");
    }
}