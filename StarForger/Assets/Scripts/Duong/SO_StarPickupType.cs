using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StarTypeData", order = 1)]
public class SO_StarPickupType : ScriptableObject
{
    public StarType starValue;
    public Sprite sprite;
    //public float dragForce;
}
