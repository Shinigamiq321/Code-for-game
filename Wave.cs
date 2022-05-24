using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject obj_Enemy;

    public int count_in_Wave;

    public float speed_Enemy;

    public float time_Spawn;

    public Transform[] path_Points;

    public bool is_return;

    [Header("Test wave!")]
    public bool is_test_Wave;

    private FollowThePath follow_Component;

    private void Start()
    {
        StartCoroutine(CreateEnemyWave());
    }
    IEnumerator CreateEnemyWave()
    {
        for(int i = 0; i < count_in_Wave; i++)
        {
            GameObject new_enemy = Instantiate(obj_Enemy, obj_Enemy.transform.position, Quaternion.identity);

            follow_Component = new_enemy.GetComponent<FollowThePath>();

            follow_Component.path_Points = path_Points;

            follow_Component.speed_Enemy = speed_Enemy;

            follow_Component.is_return = is_return;

            new_enemy.SetActive(true);

            yield return new WaitForSeconds(time_Spawn);
        }
        if (is_test_Wave)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(CreateEnemyWave());
        }
        if (!is_return)
        {
            Destroy(gameObject);
        }
    }
}
