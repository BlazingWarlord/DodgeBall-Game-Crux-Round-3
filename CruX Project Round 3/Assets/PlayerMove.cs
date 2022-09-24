using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float run_speed;
    public float sprint_speed;
    public float jump_force = 10f;
    public float jump_distance = 0.5f;
    public GameObject groundcheck;
    public bool is_ground = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = run_speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move_dir_input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move_dir = transform.TransformDirection(move_dir_input) * speed;
        is_ground = Physics.Raycast(groundcheck.transform.position, Vector3.down, jump_distance);
        rb.velocity = (new Vector3(move_dir.x,rb.velocity.y,move_dir.z));
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint_speed;
        }
        if (is_ground && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jump_force, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = run_speed;
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            this.transform.localScale = new Vector3(1,0.5f, 1);
            speed = run_speed - 10f;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            this.transform.localScale = new Vector3(1,1,1);
            speed = run_speed;
        }
        

        




    }
    
}
