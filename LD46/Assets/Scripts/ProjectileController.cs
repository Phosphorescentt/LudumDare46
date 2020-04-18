using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public int damage;
    private Vector2 dir;
    public int lifespan;
    private float throw_speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
    
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       try {

            rb.MovePosition(rb.position + (this.dir*throw_speed) * Time.deltaTime);
            StartCoroutine(thrown());

       } catch (NullReferenceException e) {

           Debug.Log("No direction specified");

       }
    
    }

    public IEnumerator thrown() {

        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);

    }

    public void setDirection(Vector2 direction) {

        this.dir = direction;

    }

    public void setSpeed(float speed) {

        this.throw_speed = speed;

    }


    //public IEnumerator throw_enum(GameObject projectile, Vector2 dir, int loopDuration, float throw_speed) {

    //    float time = 0.0f;

    //    do{

    //        
    //        time += Time.deltaTime;
    //        yield return new WaitForEndOfFrame();

    //    } while (time < loopDuration);

    //    Destroy(projectile);

    //}

    void OnCollisionEnter2D(Collision2D coll) {

        Debug.Log("Colliding");

       if(coll.gameObject.tag == "player") {
            Debug.Log("Player hit");
            HealthController health = coll.gameObject.GetComponent<HealthController>();

            health.takeDamage(damage);
            Destroy(gameObject);
       }
    }

}
