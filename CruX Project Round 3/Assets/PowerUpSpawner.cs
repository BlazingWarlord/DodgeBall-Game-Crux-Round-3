using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject move_points;
    public GameObject power_up1;
    public GameObject power_up2;
    public Vector3[] power_up_points;
    public GameObject[] power_ups;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(move_points.transform.childCount);
        power_up_points = new Vector3[10];
        power_ups[0] = power_up1;
        power_ups[1] = power_up2;
        for (int i = 0; i < 10; i++)
        {
            power_up_points[i] = new Vector3(Random.Range(-23f,23f),0.56f,Random.Range(-23f,23f));
        }

        foreach(Vector3 pup in power_up_points)
        {
            Instantiate(power_ups[Random.Range(0, 2)], pup,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
