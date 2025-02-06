using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private Vector3 startPoint;
    private Vector3 endPoint;

    public float speed;
    private bool towardsStart = true;

    private void Awake()
    {
        startPoint = start.position;
        endPoint = end.position;
    }

    void FixedUpdate()
    {
        Vector3 pos = this.gameObject.transform.position;
        if(towardsStart)
        {
            if(math.abs(pos.x - startPoint.x) < speed / 60.0f && math.abs(pos.y - startPoint.y) < speed / 60.0f)
            {
                towardsStart = !towardsStart;
            }
            pos = Vector3.MoveTowards(pos, startPoint, speed / 60.0f);
        }
        else
        {
            if (math.abs(pos.x - endPoint.x) < speed / 60.0f && math.abs(pos.y - endPoint.y) < speed / 60.0f)
            {
                towardsStart = !towardsStart;
            }
            pos = Vector2.MoveTowards(pos, endPoint, speed / 60.0f);
        }
        gameObject.transform.position = pos;
    }
}
