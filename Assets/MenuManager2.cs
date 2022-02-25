using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager2 : MonoBehaviour
{
    public GameObject settingsPanel;

    public void PlayGame()
    {
        Application.LoadLevel("Menu");
    }
}

