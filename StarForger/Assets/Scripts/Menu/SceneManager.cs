using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    [SerializeField] List<string> sceneName;

    public void LoadScene()
    {
        Application.LoadLevel(1);
    }
}
