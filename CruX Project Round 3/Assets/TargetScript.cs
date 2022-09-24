using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_Thrown_Ball")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (this.tag == "Player")
            {
                Debug.Log(this.transform.name + " hit by " + collision.transform.name);
                PlayerPrefs.SetInt("Hits", PlayerPrefs.GetInt("Hits") + 1);
                collision.gameObject.tag = "Ball";
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") - 1);
            }
            else
            {
                collision.gameObject.tag = "Ball";
            }
        }

        if (collision.gameObject.tag == "Thrown_Ball")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (this.tag == "Enemy")
            {
                Debug.Log(this.transform.name + " hit by " + collision.transform.name + "By ball of velocity" + rb.velocity.sqrMagnitude);
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
                collision.gameObject.tag = "Ball";
            }
            else
            {
                collision.gameObject.tag = "Ball";
            }
        }



    }
}


