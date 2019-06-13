using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Playgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Pullatform");
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
