using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void PlayRetry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Inst()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
