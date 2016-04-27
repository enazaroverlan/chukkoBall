using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class ChukkoLauncher : MonoBehaviour
{


    public void OnGUI()
    {
        if (GUI.Button(new Rect(30, 30, 200, 50), "Restart"))
        {
            SceneManager.LoadScene(Application.loadedLevel, LoadSceneMode.Single);
        }
    }
}
