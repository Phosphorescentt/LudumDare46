using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int dmg)
    {

        health -= dmg;

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
