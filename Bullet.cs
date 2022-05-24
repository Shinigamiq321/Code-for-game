using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    public bool is_Enemy_Bullet;

    public GameObject hitEffect;

    private void Destruction()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (is_Enemy_Bullet && coll.tag == "Player")
        {
            Player.instance.GetDamage(damage);

            Destruction();
        }
        else if ((!is_Enemy_Bullet & coll.tag == "Enemy") | coll.tag == "destr")
        {
            coll.GetComponent<Enemy>().GetDamage(damage);

            Destruction();
            
        }
        
    }
}
