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

        if(dist.magnitude < attack_range && !throwing) {

            throwing = true;
            throw_projectile(player.gameObject);

        }

    }

    public void throw_projectile(GameObject obj){

        GameObject projectile = Instantiate(projectile_prefab, this.transform.position, Quaternion.identity);
        Vector3 dir = Vector3.Normalize(this.transform.position - obj.transform.position);
        StartCoroutine(throw_enum(projectile, dir, 3));

    }

    public IEnumerator throw_enum(GameObject projectile, Vector3 dir, int loopDuration) {

        float time = 0.0f;

        do{

            projectile.transform.position = projectile.transform.position - (dir * throw_speed) * Time.deltaTime;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } while (time < loopDuration);

        throwing = false;        

    }

}
