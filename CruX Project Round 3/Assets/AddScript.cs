using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScript : MonoBehaviour
{
    public GameObject ball;
    private void OnEnable()
    {
        Destroy(this.GetComponent<EnemyThrow>());
        EnemyThrow et = this.gameObject.AddComponent<EnemyThrow>();
        et.throw_speed = 300000;
        et.ball_prefab = ball;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
