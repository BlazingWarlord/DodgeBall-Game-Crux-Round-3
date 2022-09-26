using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public PlayerMove pm;
    public GameObject ball_prefab;
    public Transform big_ball;
    public AudioSource ps_sound;
    float delay = 1.5f;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && this.gameObject.tag == "Jump_High")
        {

            if (PlayerPrefs.GetInt("Health") > 4)
            {
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
            }
            ps_sound.Play();
            col.enabled = false;
            Destroy(this.gameObject, 1.5f);
        }

        if(other.tag == "Player" && this.gameObject.tag == "SloMo")
        {
            if (PlayerPrefs.GetInt("Health") < 10)
            {
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);
            }
            ps_sound.Play();
            col.enabled = false;
            Destroy(this.gameObject, 1.5f);


        }

        
    }

    
}
