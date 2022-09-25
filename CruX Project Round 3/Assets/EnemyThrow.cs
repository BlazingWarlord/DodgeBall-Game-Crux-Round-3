using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public GameObject ball_prefab;
    public float throw_speed;
    public bool waitdone = true;
    public float delay_no;
    bool isc;
    bool isc1;
    
    public float throw_error = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isc = false;
        isc1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        throw_error = 0.2f - PlayerPrefs.GetInt("Score")/50f;
        if(throw_error < 0f)
        {
            throw_error = 0f;
        }
        if(transform.childCount < 1 && waitdone)
        {
            
            Collider[] balls = Physics.OverlapSphere(transform.position, 2.5f);
            foreach(Collider ball in balls)
            {
                if(transform.childCount < 1 && ball.transform.tag == "Ball" && ball.gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude < 5f)
                {
                    Destroy(ball.gameObject);
                    GameObject ball_new = Instantiate(ball_prefab, transform);
                    ball_new.transform.tag = "Holding_Ball";
                    
                    StartCoroutine(waitbeforethrow());
                    
                    
                }
            }
        }

        else
        {
            RaycastHit target;
            if (Physics.Raycast(transform.position, transform.forward, out target))
                
            {
                Debug.Log(target.transform.name);
                if (target.transform.tag == "Player")
                {
                    GameObject ball = transform.GetChild(0).gameObject;
                    Rigidbody ball_rb = ball.GetComponent<Rigidbody>();

                    if (!isc1)
                    {

                        ball_rb.useGravity = true;
                        ball_rb.isKinematic = false;
                        ball_rb.AddForce((transform.forward.normalized + new Vector3(Random.Range(-throw_error,throw_error),0.01f,0)) * throw_speed * Time.deltaTime);
                        ball.transform.parent = null;
                        ball.transform.tag = "Enemy_Thrown_Ball";
                        Debug.Log("Enemy Threw Ball");
                        waitdone = false;
                        if(!isc)
                        {
                            StartCoroutine(delay());
                        }
                        ball = null;
                    }
                }
            }
        }
    }

    IEnumerator delay()
    {
        isc = true;
        yield return new WaitForSeconds(1);
        waitdone = true;
        isc = false;
    }

    IEnumerator waitbeforethrow()
    {
        isc1 = true;
        delay_no = Random.Range(0.2f,2f);
        yield return new WaitForSeconds(delay_no);
        isc1 = false;
    }
}
