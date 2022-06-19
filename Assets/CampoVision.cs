using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoVision : MonoBehaviour
{

    /*public Transform player;
    public Transform head;
    [Range (0f, 360f)];
    public float visionAngle = 30f:
    public float visionDistance = 10f;
    bool detected = false;*/
    public Transform target;
    Vector3 v = Vector3.zero;
    float distance = 0.0f;

    public float radius = 1.0f;

    public float dot = 0.0f;

    public float fov = 30.0f;
    public float dotFov = 0.0f;

    private void OnDrawGizmos()
    {
        /*if (visionAngle <= 0f) return;
        float halfVisionAngle = visionAngle * 0.5f;
        Vector2 p1, p2;
        p1 = PointForAngle(halfVisionAngle, visionDistance);
        p2 = PointForAngle(-halfVisionAngle, visionDistance);*/
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);

        v = target.position - transform.position;
        distance = v.sqrMagnitude;

        v.Normalize();

        dotFov = Mathf.Cos(fov * 0.5f * Mathf.Deg2Rad);
        dot = Vector3.Dot(transform.forward, v);

        Debug.Log(dot);

        if ((distance <= radius * radius) && (dot >= dotFov))
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = new Color(0f, 0.7f, 0f, 1f);
        }

        Gizmos.DrawLine(transform.position, target.position);
        
    }

    /*Vector3 PointForAngle(float angle, float distance)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
