using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class testUnlockButton : MonoBehaviour
{
    [SerializeField] Image unlockImage;
    [SerializeField] Sprite lockedSprite;
    [SerializeField] Sprite unlockedSprite;

    [SerializeField] float time = 0.2f;
    [SerializeField] Image flashImage;
    Vector2 flashUiScale;
    Color norColor = Color.white;
    Color hitColor;
    public Ease EaseType;

    public void Start()
    {
        unlockImage.sprite = lockedSprite;

        flashUiScale = flashImage.rectTransform.sizeDelta;

        flashImage.rectTransform.sizeDelta = flashUiScale;
        flashImage.gameObject.SetActive(true);
    }

    public void Click()
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
        sequence.Append(unlockImage.GetComponent<RectTransform>().DOSizeDelta(new Vector2(100,100), time));


        flashImage.rectTransform.sizeDelta = flashUiScale;
        flashImage.color = norColor;



        yield return sequence.WaitForCompletion();
    }
}
