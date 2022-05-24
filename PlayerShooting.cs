using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject obj_Bullet;

    public float time_Bullet_Spawn = 0.3f;

    [HideInInspector]
    public float timer_Shot;
    private void Update()
    {
        if(Time.time > timer_Shot)
        {
            timer_Shot = Time.time + time_Bullet_Spawn;

            Instantiate(obj_Bullet, transform.position, Quaternion.identity);
        }
    }
}
