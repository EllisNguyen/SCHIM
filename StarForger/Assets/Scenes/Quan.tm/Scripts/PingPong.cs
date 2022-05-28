using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float travelDistance;

    Vector3 startPos;

    public bool pingPong;
    public bool reverse;
    public bool x;
    public bool z;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pingPong)
        {
            if (reverse)
            {
                if (x)
                {
                    transform.position = new Vector3(startPos.x - Mathf.PingPong(Time.time, travelDistance), transform.position.y, transform.position.z);
                }
                if (z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z - Mathf.PingPong(Time.time, travelDistance));
                }
            }
            else
            {
                if (x)
                {
                    transform.position = new Vector3(startPos.x + Mathf.PingPong(Time.time, travelDistance), transform.position.y, transform.position.z);
                }
                if (z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, startPos.z + Mathf.PingPong(Time.time, travelDistance));
                }
            }
        }
    }
}
