using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public HealthController health;
    private Rigidbody2D rb;
    public PlayerShooter shooter;
    public InventoryManager inv;
    public UIManager ui;

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

        if(Input.GetButtonUp("Fire1")) {

            Debug.Log("Shooting");
            shooter.shoot();            

        }

        if(Input.GetButtonUp("Fire2")) {

            Debug.Log("Using Item");
            inv.items[inv.active_item].use();

        }

    }
    
    void FixedUpdate() {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed,
                                  Input.GetAxis("Vertical") * speed,
                                  0f);

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }



}
