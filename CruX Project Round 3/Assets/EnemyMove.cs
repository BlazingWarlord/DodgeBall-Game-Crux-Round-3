using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyMove : MonoBehaviour
{
    bool isc = false;
    public NavMeshAgent nam;
    public GameObject move_points;
    public Transform[] move_point;
    float speed = 3.5f;
    public GameObject player;
    public GameObject ball_holder_object;
    public GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {

        move_point = new Transform[move_points.transform.childCount];
        nam = GetComponent<NavMeshAgent>();
        for(int i = 0;i<move_points.transform.childCount; i++)
        {
            move_point[i] = move_points.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nam.speed = speed;
        transform.LookAt(player.transform);
        if(!isc)
        {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        isc = true;
        if (ball_holder_object.transform.childCount < 1)
        {
            balls = GameObject.FindGameObjectsWithTag("Ball");
            balls = balls.OrderBy((d) => (d.transform.position - transform.position).sqrMagnitude).ToArray();
            nam.SetDestination(balls[Random.Range(0,2)].transform.position);

        }
        else
        {   
            yield return new WaitForSeconds(Random.Range(2, 5));
            nam.SetDestination(move_point[Random.Range(0, move_point.Length)].position);
        }
        nam.speed = speed += PlayerPrefs.GetInt("Score")/5;
        isc = false;
    }
}
