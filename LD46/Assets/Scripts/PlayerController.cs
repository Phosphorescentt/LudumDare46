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
        

        if (Input.GetKeyUp("b"))
        {
            health.bleed(5, 10);
        }
    }
    
    void FixedUpdate() {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed,
                                  Input.GetAxis("Vertical") * speed,
                                  0f);

    }



}
