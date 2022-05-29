using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{

    [SerializeField] List<LevelSelectButton> levelButtons;

    private void Awake()
    {
        for (int i = 0; i < LevelManager.Instance.Scenes.Count; i++)
        {
            levelButtons[i].name = $"Load scene {LevelManager.Instance.Scenes[i].SceneName} - currently {LevelManager.Instance.Scenes[i].LevelState}";
            levelButtons[i].levelToLoad = LevelManager.Instance.Scenes[i].SceneName;

            if (LevelManager.Instance.Scenes[i].LevelState == LevelState.Unlocked)
            {
                levelButtons[i].ReadyToPlay();
            }

            if (LevelManager.Instance.Scenes[i].LevelState == LevelState.Available)
                levelButtons[i].buttonState = ButtonState.Available;
        }
    }
}