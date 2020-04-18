using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator throw_enum(GameObject projectile, Vector3 dir, int loopDuration, float throw_speed) {

        float time = 0.0f;

        do{

            projectile.transform.position = projectile.transform.position - (dir * throw_speed) * Time.deltaTime;
            
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();

        } while (time < loopDuration);

        Destroy(projectile);

    }
}
