using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WayPointElement
{
    public Vector3 pos;
    public float intervalToNextPos;
}

public class WayPoint : MonoBehaviour
{
    [SerializeField] private List<WayPointElement> wayPointList = new List<WayPointElement>();

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, GameManager.Instance.globalYPos, transform.position.z);
        
        for(var i = 0; i< wayPointList.Count; i++)
        {
            wayPointList[i].pos = new Vector3( wayPointList[i].pos.x, GameManager.Instance.globalYPos,  wayPointList[i].pos.z);
        }

        StartCoroutine(BeginMoveRoutine());
    }

    private IEnumerator BeginMoveRoutine()
    {
        for (int i = 0; i < wayPointList.Count; i++)
        {
            if (i + 1 < wayPointList.Count)
            {
                yield return LerpToNextPosRoutine(wayPointList[i].pos, wayPointList[i + 1].pos,
                    wayPointList[i].intervalToNextPos);
            }
            else
            {
                print($"hellow");
                yield return LerpToNextPosRoutine(wayPointList[i].pos, wayPointList[0].pos,
                    wayPointList[i].intervalToNextPos);
                i = -1;
            }
        }
    }
    
    private IEnumerator LerpToNextPosRoutine(Vector3 start, Vector3 end, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(start, end, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < wayPointList.Count; i++)
        {
            Gizmos.DrawWireSphere(wayPointList[i].pos, 1f);
        }
    }
}
