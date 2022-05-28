using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLine : MonoBehaviour
{

    [SerializeField] RectTransform[] points;
    [SerializeField] LineControl lineRenderer;

    private void Start()
    {
        lineRenderer.SetUpLine(points);
    }
}
