using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AnimatedUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] RectTransform holder;
    [SerializeField] float time = 0.2f;
    [SerializeField] Vector2 moveTo;
    Vector2 origin = new Vector2(0,0);

    [SerializeField] CanvasGroup pressAnykey;
    [SerializeField] Image anykeyPressedAnim;
    public Ease EaseType;

    // Start is called before the first frame update
    void Start()
    {
        holder.anchoredPosition = origin;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        holder.DOAnchorPos(moveTo, time);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        holder.DOAnchorPos(origin, time);
    }

    public void Click()
    {
        StartCoroutine(TitleTransitionSequence());
    }

    IEnumerator TitleTransitionSequence()
    {
        var sequence = DOTween.Sequence();
        RectTransform animRect = anykeyPressedAnim.GetComponent<RectTransform>();

        sequence.Append(anykeyPressedAnim.DOFade(1, 0.075f).SetEase(this.EaseType));
        sequence.Join(animRect.DOSizeDelta(new Vector2(550, 1), 0.25f).SetEase(this.EaseType));
        sequence.Join(pressAnykey.DOFade(0, time).SetEase(this.EaseType));
        sequence.Insert(0.08f, anykeyPressedAnim.DOFade(0, 0.075f).SetEase(this.EaseType));
        yield return sequence.WaitForCompletion();

        anykeyPressedAnim.gameObject.SetActive(false);

        yield return new WaitForSeconds(time);
    }
}
