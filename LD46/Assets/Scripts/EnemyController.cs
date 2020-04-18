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
    public bool throwing = false;
    public float stopping_dist;
    public int throw_cooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();  
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dist = this.transform.position - player.transform.position;

        if (dist.magnitude < range && dist.magnitude > stopping_dist || !ranged)
        {
            Debug.DrawLine(this.transform.position, player.transform.position);
            this.transform.position = this.transform.position - (Vector3.Normalize(dist) * speed) * Time.deltaTime;
        }

        if(dist.magnitude < attack_range && !throwing) {

            throwing = true;
            throw_projectile(player.gameObject);

        }

    }

    public void throw_projectile(GameObject obj){

        GameObject projectile = Instantiate(projectile_prefab, this.transform.position, Quaternion.identity);
        Vector3 dir = Vector3.Normalize(this.transform.position - obj.transform.position);
        StartCoroutine(projectile.GetComponent<ProjectileController>().throw_enum(projectile, dir, 1, throw_speed));
        StartCoroutine(wait_for_throw());

    }

    public IEnumerator wait_for_throw() {
    
        yield return new WaitForSeconds(throw_cooldown);
        throwing = false;
    
    }


}
