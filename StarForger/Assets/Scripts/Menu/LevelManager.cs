using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] AvailableScene menuScene;
    [SerializeField] List<AvailableScene> scenes;
    public List<AvailableScene> Scenes => scenes;

    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadMenu(string sceneName = "MainMenu")
    {
        SceneManager.LoadScene(sceneName);
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
                else if (scenes[i].LevelState == LevelState.Unlocked)
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            if (sceneIndex == scenes[i].SceneIndex)
            {
                if (scenes[i].LevelState == LevelState.Locked)
                {
                    Debug.LogError($"{scenes[i].SceneName} not yet unlocked.");
                    return;
                }
                else if (scenes[i].LevelState == LevelState.Unlocked)
                {
                    SceneManager.LoadScene(sceneIndex);
                }
            }
        }
    }

    public void ActivateScene(string name)
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            if (scenes[i].SceneName == name)
                scenes[i].LevelState = LevelState.Unlocked;
        }
    }

    public void ActivateScene(int index)
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            if (scenes[i].SceneIndex == index)
                scenes[i].LevelState = LevelState.Available;
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
    public LevelState LevelState
    {
        get { return levelState; }
        set { levelState = value; }
    }

    public void ActivateScene()
    {
        levelState = LevelState.Unlocked;
    }
}

public enum LevelState { Locked, Available, Unlocked }