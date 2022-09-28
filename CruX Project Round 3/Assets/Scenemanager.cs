using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Scenemanager : MonoBehaviour
{
    public Slider sensitivity;
    public Slider fov;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        string path = Application.persistentDataPath + "/high.score";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerPrefs.SetInt("HighScore",(int)formatter.Deserialize(stream));
            stream.Close();
        }
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
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/high.score";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, PlayerPrefs.GetInt("HighScore"));
        stream.Close();
        Application.Quit();
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/high.score";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, PlayerPrefs.GetInt("HighScore"));
        stream.Close();
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
        PlayerPrefs.SetFloat("FOV",fov.value);
        
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(5);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(6);
    }

    public void ResetHighScore()
    {
        Debug.Log("Pressed");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/high.score";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, 0);
        PlayerPrefs.SetInt("HighScore", 0);
        stream.Close();
    }
}
