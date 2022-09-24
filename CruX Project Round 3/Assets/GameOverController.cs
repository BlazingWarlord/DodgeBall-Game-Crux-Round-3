using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public GameObject GOPanel;
    public Animator GOPanelAnimator;
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        GOPanelAnimator = GOPanel.GetComponent<Animator>();
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
            Cursor.lockState = CursorLockMode.None;
        }
    }

    
}
