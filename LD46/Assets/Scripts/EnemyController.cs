using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private PlayerController player;
    public float range = 5f;
    public bool ranged = true;
    public float speed = 0.7f;
    public GameObject projectile_prefab;
    public float throw_speed;
    public float attack_range = 2f;
    private bool throwing = false;
    public float stopping_dist;
    public int throw_cooldown = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();  
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 dist = this.transform.position - player.transform.position;

        if (dist.magnitude < range && dist.magnitude > stopping_dist || !ranged)
        {
            Debug.DrawLine(this.transform.position, player.transform.position);
            rb.velocity = -dist.normalized * speed;
        } else if(dist.magnitude <= stopping_dist) {
            rb.velocity = Vector3.zero;
        } else if(dist.magnitude > range) {
            rb.velocity = Vector3.zero;
        }


        if(dist.magnitude < attack_range && !throwing) {

            throwing = true;
            throw_projectile(player.gameObject);

        }

    }

    public void throw_projectile(GameObject obj){

        Vector3 dir = (this.transform.position - obj.transform.position).normalized;
        GameObject projectile = Instantiate(projectile_prefab, this.transform.position + dir*-1f, Quaternion.identity);
        projectile.GetComponent<ProjectileController>().setDirection(dir);
        projectile.GetComponent<ProjectileController>().setSpeed(throw_speed);
        StartCoroutine(wait_for_throw());

    }

    public IEnumerator wait_for_throw() {
    
        yield return new WaitForSeconds(throw_cooldown);
        throwing = false;
    
    }


}
