using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
 
    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
