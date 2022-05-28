using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{

    [SerializeField] List<LevelSelectButton> levelButtons;
    [SerializeField] GameObject buttonsHolder;

    private void Awake()
    {
        for (int i = 0; i < LevelManager.Instance.Scenes.Count; i++)
        {
            levelButtons[i].name = $"Load scene {LevelManager.Instance.Scenes[i].SceneName} - currently {LevelManager.Instance.Scenes[i].LevelState}";
        }
    }

}