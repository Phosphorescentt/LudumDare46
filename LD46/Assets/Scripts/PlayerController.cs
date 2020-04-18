using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public HealthController health;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey("up")) {

            rb.MovePosition(rb.position + (Vector2.up * speed) * Time.deltaTime);

        }


        if(Input.GetKey("down")) {

            rb.MovePosition(rb.position + (Vector2.down * speed) * Time.deltaTime);

        }


        if(Input.GetKey("left")) {

            rb.MovePosition(rb.position + (Vector2.left * speed) * Time.deltaTime);

        }


        if(Input.GetKey("right")) {

            rb.MovePosition(rb.position + (Vector2.right * speed) * Time.deltaTime);

        }
        

        if (Input.GetKeyUp("b"))
        {
            health.bleed(5, 10);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {

        Debug.Log("Colliding Player");

    }

}
