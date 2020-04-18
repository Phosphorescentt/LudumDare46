using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float max_health;
    private float health;
    public bool is_player = false;
    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int dmg)
    {

        if(is_player) {
            this.gameObject.GetComponent<PlayerController>().ui.changeHealth(dmg);
        }

        health -= dmg;

        if(health == 0) {

            if(is_player) {
                // End game
            } else {

                die();

            }

        }

    }

    private void die() {

        // Do some animation
        Destroy(gameObject);

    }

    public float get_health() {

        return health;

    }

    public void set_health(int new_health) {

        health = new_health;

    }

    public void bleed(int seconds, int dmg)
    {

        StartCoroutine(bleed_enum(seconds, dmg));

    }

    public IEnumerator bleed_enum(int seconds, int dmg)
    {

        Debug.Log("Taking damage");

        for (int i = 0; i < seconds; i++)
        {

            health -= dmg;
            
            yield return new WaitForSeconds(2f);

        }

    }
}
