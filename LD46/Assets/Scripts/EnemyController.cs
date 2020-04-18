using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private PlayerController player;
    public float range = 5;
    public bool ranged = true;
    public float speed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();  
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
