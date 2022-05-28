using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<AvailableScene> scenes;

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadScene(string sceneName)
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            if (sceneName == scenes[i].SceneName)
            {
                if (scenes[i].LevelState == LevelState.Locked)
                {
                    Debug.LogError($"{scenes[i].SceneName} not yet unlocked.");
                    return;
                }
                else
                {
                    SceneManager.LoadScene(scenes[i].SceneName);
                }
            }
        }
    }
}

[System.Serializable]
public class AvailableScene
{
    [SerializeField] string sceneName;
    [SerializeField] int sceneIndex;
    [SerializeField] LevelState levelState;

    public string SceneName => sceneName;
    public int SceneIndex => sceneIndex;
    public LevelState LevelState => LevelState;
}

public enum LevelState { Locked, Available }