using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Image healthbar;
    public int fill_speed;
    public float health;
    public GameObject player;
    private HealthController health_cntrl;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.fillAmount = 1f;
        health_cntrl = player.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(float dmg, bool healing=false) {

        Debug.Log("Changing health");

        if(healing) {

            dmg = -dmg;

        }

        healthbar.fillAmount = (health_cntrl.get_health() - dmg) / health_cntrl.max_health;

    }

}
