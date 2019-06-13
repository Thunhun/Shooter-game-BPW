using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public GameObject WinUI;

    private void OnTriggerEnter()
    {
        win();
    }

    void win()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0f;
        Pausemenu.GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   
}

