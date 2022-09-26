using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody ball_rb;
    public GameObject main_camera;
    public float throw_speed;
    public bool is_holding = true;
    public GameObject ball_prefab;
    
    
    // Start is called befo
    // re the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            ball = transform.GetChild(0).gameObject;
        }
        
        if (ball != null)
        {
            ball_rb = ball.GetComponent<Rigidbody>();
            
            if(Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
            {
                ball_rb.isKinematic = false;
                ball_rb.useGravity = true;
                
                ball_rb.AddForce((main_camera.transform.forward + new Vector3(0,0.025f,0)) * throw_speed * Time.deltaTime);
                ball.transform.parent = null;
                is_holding = false;
                ball.transform.tag = "Thrown_Ball";
                ball = null;
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            Collider[] balls = Physics.OverlapSphere(transform.position, 2f);
            foreach(Collider ball in balls)
            {
                
                if(ball.transform.tag == "Ball" && !is_holding)
                {
                    Destroy(ball.gameObject);
                    GameObject ball_new = Instantiate(ball_prefab,transform);
                    is_holding = true;
                    ball_new.transform.tag = "Holding_Ball";
                }
            }
        }
    }

  
}
