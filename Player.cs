using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public int player_Health = 1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GetDamage(int damage)
    {
        player_Health -= damage;
        if(player_Health <= 0)
        {
            Destruction();
        }
    }
    public void Destruction()
    {
        Destroy(gameObject);
    }
}
