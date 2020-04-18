using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    public GameObject projectile_prefab;
    public float shoot_speed;
    public float cooldown_length = 1f;
    public float cooldown = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(cooldown > 0) {

            cooldown -= Time.deltaTime;

        }
        
    }


    public void shoot() {

        if(cooldown <= 0){
            Vector3 pos = this.transform.position + transform.right;
            Debug.Log(pos);
            GameObject projectile = Instantiate(projectile_prefab, pos, Quaternion.identity);
            projectile.GetComponent<ProjectileController>().setDirection(-transform.right);
            projectile.GetComponent<ProjectileController>().setSpeed(shoot_speed);
            cooldown = cooldown_length;
        }
    }
}
