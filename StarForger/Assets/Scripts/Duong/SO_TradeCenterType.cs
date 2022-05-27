using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TradeCenterData", order = 1)]
public class SO_TradeCenterType : ScriptableObject
{
    public StarType inputStar;
    public StarType outputStar;
    
    //public List<SO_StarPickupType> starPickupTypeList = new List<SO_StarPickupType>();
}
