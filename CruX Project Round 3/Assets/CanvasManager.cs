using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TMP_Text score;
    //public TMP_Text hits;
    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score",0);
        PlayerPrefs.SetInt("Hits", 0);
        PlayerPrefs.SetInt("Health",10);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
        //hits.text = "Hits: " + (10 - PlayerPrefs.GetInt("Health")).ToString();
        health.value = PlayerPrefs.GetInt("Health");

    }
}
