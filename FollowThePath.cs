using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] path_Points;

    public float speed_Enemy;

    public bool is_return;

    public Vector3[] _new_Position;

    private int cur_Pos;

    private void Start()
    {
        _new_Position = NewPositionByPath(path_Points);
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _new_Position[cur_Pos], speed_Enemy * Time.deltaTime);
        if(Vector3.Distance(transform.position,_new_Position[cur_Pos]) < 0.2f)
        {
            cur_Pos++;
            if(is_return && Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.3f)
            {
                cur_Pos = 0;
            }
        }
        if(Vector3.Distance(transform.position, _new_Position[_new_Position.Length - 1]) < 0.2f && !is_return)
        {
            Destroy(gameObject);
        }
    }
    Vector3[] NewPositionByPath(Transform[] pathPos)
    {
        Vector3[] pathPositions = new Vector3[pathPos.Length];
        for (int i = 0; i < path_Points.Length; i++)
        {
            pathPositions[i] = pathPos[i].position;
        }
       
        
        return pathPositions;
    }
    
}
