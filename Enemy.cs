using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy health.
    public int enemy_Health;

    [Space]

    public GameObject obj_Bullet;

    public float shot_Time_Max, shot_Time_Min;

    public float shot_Chance;
    // Method of taking damage by the enemy
    private void Update()
    {
        Invoke("OpenFire", Random.Range(shot_Time_Min, shot_Time_Max));
    }
    private void OpenFire()
    {
        if(Random.value < (float)shot_Chance / 100)
        {
            Instantiate(obj_Bullet, transform.position, Quaternion.identity);
        }
    }
        
    public void GetDamage(int damage)
    {
        // Reduce the health by the damage amount.
        enemy_Health -= damage;
        // If the enemy does not have a health...
        if (enemy_Health <= 0)
        {
            // Call the enemy destruction method
            Destruction();
        }
    }
    // Method destruction enemy.
    private void Destruction()
    {
        // Destroy the current player object.
        Destroy(gameObject);
    }
    //if enemy collides player, Player gets the damage. 
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GetDamage(1);
        }
    }
}
//Права на данный курс принадлежат Дорофеевой Карине Олеговне, данный курс создавался для Udemy сайта