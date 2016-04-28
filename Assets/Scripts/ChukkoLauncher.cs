using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class ChukkoLauncher : MonoBehaviour
{
    public GameObject ChukkoObject;
    [HideInInspector]
    public static List<string> message = new List<string>();

    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            GameObject inst_ball = Instantiate(ChukkoObject, transform.position, transform.rotation) as GameObject;
            inst_ball.gameObject.AddComponent<ChukkoInAir>();
            inst_ball.GetComponent<ChukkoInAir>().RotateCase = 20;
            inst_ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * 3, ForceMode.Impulse);
        }*/
    }

    public void OnGUI()
    {
        if (GUI.Button(new Rect(30, 30, 200, 50), "Restart"))
        {
            SceneManager.LoadScene(Application.loadedLevel, LoadSceneMode.Single);
        }

        if (GUI.Button(new Rect(30, 80, 200, 50), "Exit"))
        {
            Application.Quit();
        }

        GUILayout.BeginArea(new Rect(Screen.width - 300, 0, 290, 300), "", "Box");
        scrolPos = GUILayout.BeginScrollView(scrolPos);
        foreach (string s in message)
        {
            GUILayout.Label(s);
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }
    Vector2 scrolPos = Vector2.zero;
}
