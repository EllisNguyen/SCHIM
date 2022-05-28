/*--------------------------------------
Author: Quan Nguyen
Created on: 22/08/21
+---------------------------------------
Last modified by: Quan Nguyen
--------------------------------------*/

using UnityEngine;

/// <summary>
/// Basic Singleton Class. Make any class inherit from this one to turn it into a Singleton.
/// This class must be added onto an object.
/// No extra features.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //getter and setter of the instance
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));
        }
        else
        {
            //if the instance already exists, destroy it to prevent duplicates
            Destroy(gameObject);
        }
    }
}
