using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player;
    public float range = 5;
    public float speed = 0.7f;
    public bool ranged = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");  
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dist = this.transform.position - player.transform.position;

        if (dist.magnitude < range || !ranged)
        {
            Debug.DrawLine(this.transform.position, player.transform.position);
            this.transform.position = this.transform.position - (Vector3.Normalize(dist) * speed) * Time.deltaTime;
        }
    }
}
