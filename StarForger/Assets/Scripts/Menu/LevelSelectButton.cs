using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public enum ButtonState { Locked, Available, Unlocked}

public class LevelSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string levelToLoad;

    [SerializeField] Image unlockImage;
    [SerializeField] Sprite lockedSprite;
    [SerializeField] Sprite unlockedSprite;

    [SerializeField] float time = 0.2f;
    [SerializeField] Image flashImage;
    Vector2 flashUiScale;
    Color norColor = Color.white;
    Color hitColor;
    public Ease EaseType;

    [SerializeField] Image availableImage;
    Vector2 availableOrigin;
    public Color noColor;
    float blinkTimer = 1.25f;

    public ButtonState buttonState;

    private void Start()
    {
        availableOrigin = availableImage.GetComponent<RectTransform>().sizeDelta;

        switch (buttonState)
        {
            case ButtonState.Locked:
                break;
            case ButtonState.Available:
                AvailableBlink();
                break;
            case ButtonState.Unlocked:
                break;
            default:
                break;
        }
    }

    public void Init()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void Unlock()
    {
        StartCoroutine(UnlockSequence());
    }

    public IEnumerator UnlockSequence()
    {
        var sequence = DOTween.Sequence();
        RectTransform animRect = flashImage.GetComponent<RectTransform>();

        sequence.Append(flashImage.DOFade(1, 0.075f).SetEase(this.EaseType));
        sequence.Join(animRect.DOSizeDelta(new Vector2(550, 1), 0.1f).SetEase(this.EaseType));

        unlockImage.sprite = unlockedSprite;

        //Flick color when hit.
        sequence.Append(unlockImage.DOColor(hitColor, 0.1f));

        //Return to original color.
        sequence.Append(unlockImage.DOColor(Color.white, 0.1f));

        //Flick color when hit.
        sequence.Append(unlockImage.DOColor(hitColor, 0.1f));

        //Return to original color.
        sequence.Append(unlockImage.DOColor(Color.white, 0.1f));

        sequence.Join(flashImage.DOFade(0, time).SetEase(this.EaseType));
        sequence.Insert(0.08f, flashImage.DOFade(0, 0.075f).SetEase(this.EaseType));

        sequence.Append(unlockImage.DOColor(hitColor, 0.25f));
        sequence.Append(unlockImage.GetComponent<RectTransform>().DOSizeDelta(new Vector2(100, 100), time));


        flashImage.rectTransform.sizeDelta = flashUiScale;
        flashImage.color = norColor;



        yield return sequence.WaitForCompletion();
    }

    public void AvailableBlink()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(availableImage.DOColor(noColor, blinkTimer));//.SetLoops(-1, LoopType.Restart));
        sequence.Join(availableImage.GetComponent<RectTransform>().DOSizeDelta(availableOrigin * 2f, blinkTimer));//.SetLoops(-1));

        sequence.AppendInterval(blinkTimer);
        sequence.SetLoops(-1, LoopType.Restart);
        sequence.SetRelative(true);
    }
}
