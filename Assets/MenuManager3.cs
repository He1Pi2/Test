using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager3 : MonoBehaviour
{
    public GameObject settingsPanel;

    public void CutScene()
    {
        Application.LoadLevel("CutScene");
    }
}
