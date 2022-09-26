using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public GameObject GOPanel;
    public Animator GOPanelAnimator;
    public TMP_Text score;
    public bool is_paused = false;
    public GameObject pause_menu;
    public AudioSource go_music;
    // Start is called before the first frame update
    void Start()
    {
        GOPanelAnimator = GOPanel.GetComponent<Animator>();
        go_music = GOPanel.GetComponent<AudioSource>();
        pause_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerPrefs.GetInt("Health") <= 0)
        {
            GOPanel.SetActive(true);
            
            Time.timeScale = 0;
            score.text = "Score: " + PlayerPrefs.GetInt("Score");
            GOPanelAnimator.Play("GameOverAnim");
            go_music.enabled = true;
            Cursor.lockState = CursorLockMode.None;
        }

       if(PlayerPrefs.GetInt("Health") > 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            is_paused = !is_paused;
            if(is_paused)
            {
                Time.timeScale = 0;
                pause_menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                pause_menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    
}
