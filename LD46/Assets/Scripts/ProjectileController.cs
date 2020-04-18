using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public int damage;
    private Vector3 dir;
    public int lifespan;
    private float throw_speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
    
        StartCoroutine(thrown());
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = this.gameObject.transform.position - (dir*throw_speed) * Time.deltaTime;

    }

    public IEnumerator thrown() {

        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);

    }

    public void setDirection(Vector3 direction) {

        this.dir = direction;

    }

    public void setSpeed(float speed) {

        this.throw_speed = speed;

    }


    //public IEnumerator throw_enum(GameObject projectile, Vector3 dir, int loopDuration, float throw_speed) {

    //    float time = 0.0f;

    //    do{

    //        
    //        time += Time.deltaTime;
    //        yield return new WaitForEndOfFrame();

    //    } while (time < loopDuration);

    //    Destroy(projectile);

    //}

    void OnCollisionEnter2D(Collision2D coll) {


       if(coll.gameObject.tag == "player") {
            Debug.Log("Player hit");
            HealthController health = coll.gameObject.GetComponent<HealthController>();

            health.takeDamage(damage);
            Destroy(gameObject);
       }
    }

}
