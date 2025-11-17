using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
