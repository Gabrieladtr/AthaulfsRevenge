// Code written by tutmo (youtube.com/tutmo)
// For help, check out the tutorial - https://youtu.be/PNWK5o9l54w

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SelectScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
