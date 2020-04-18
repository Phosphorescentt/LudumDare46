using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {

            this.transform.position = this.transform.position + (Vector3.up * speed) * Time.deltaTime;

        }

        if (Input.GetKey("down"))
        {

            this.transform.position = this.transform.position + (Vector3.down * speed) * Time.deltaTime;

        }

        if (Input.GetKey("left"))
        {

            this.transform.position = this.transform.position + (Vector3.left * speed) * Time.deltaTime;

        }

        if (Input.GetKey("right"))
        {

            this.transform.position = this.transform.position + (Vector3.right * speed) * Time.deltaTime;

        }
    }
}
