using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetUI : UIContainer
{
    public TextMeshProUGUI m_Title;
    public Slider rightSlider;
    public Slider leftSlider;
    [Space(10)]
    public PlayerUI _Player1UI;
    public PlayerUI _Player2UI;

    [Header("Animation")]
    private float animTime = 1f;
    private float BetUIposXoffSet = 100; // Container width + offset.
    private int animTitlePosY = -240;
    private Sequence betAnim;

    public override void SetContainer()
    {
        m_Title.rectTransform.anchoredPosition = Vector2.zero;
        _Player1UI.Rect.anchoredPosition = new Vector2((_Player1UI.Rect.sizeDelta.x + BetUIposXoffSet) * -1, 0);
        _Player2UI.Rect.anchoredPosition = new Vector2(_Player2UI.Rect.sizeDelta.x + BetUIposXoffSet, 0);
    }

    public override void ShowContainer()
    {
        base.ShowContainer();
    }

    public void UpdateTimeUI(float percentage)
    {
        rightSlider.value = percentage;
        leftSlider.value = percentage;
    }

    public void BetAnimIn(Action OnAnimEnd) 
    {
        betAnim = DOTween.Sequence().SetAutoKill(false).SetEase(Ease.Linear)
            .Append(m_Title.rectTransform.DOAnchorPosY(animTitlePosY, animTime * .5f))
            .Append(_Player1UI.Rect.DOAnchorPosX(0, animTime *.5f))
            .Join(_Player2UI.Rect.DOAnchorPosX(0, animTime * .5f))
            .OnComplete(() => OnAnimEnd?.Invoke());
    }
}

[Serializable]
public class PlayerUI
{
    public RectTransform Rect;
    public ToggleGroup betToggles;
    public ToggleGroup upgradesToggles;
}
