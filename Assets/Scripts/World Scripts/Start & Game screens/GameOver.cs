using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKey("r"))
        {
            GoNextScene();
        }
    }
    public void GoNextScene()
    {
        SceneManager.LoadScene(1);
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}