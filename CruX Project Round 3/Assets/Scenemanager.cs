using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenemanager : MonoBehaviour
{
    public Slider sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Health", 10);
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(0);
    }

    public void LightLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }
    public void Maze()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }
    public void HologramLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        PlayerPrefs.SetInt("Sensitivity",(int)sensitivity.value);
        
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(5);
    }
}
