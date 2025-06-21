using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : UIContainer
{
    public TextMeshProUGUI m_Title;
    public Button m_StartButton;

    [Header("Anim Settings")]
    public int initialCamPosZ = 13;
    private int animCamPosZ = -13;
    private float animTime = 1f;

    public override void SetContainer()
    {
        base.SetContainer();
        m_StartButton.interactable = false;
    }

    public void SetStartButton(Action OnClick) 
    {
        m_StartButton.onClick.AddListener(()=> OnClick.Invoke());
        m_StartButton.interactable = true;
    }

    public void MenuAnim(Transform cam, Action OnAnimEnd) 
    {
        Sequence anim = DOTween.Sequence().SetEase(Ease.Linear)
            .Append(_container.DOFade(0, animTime * .3f))
            .Join(cam.DOMoveZ(animCamPosZ, animTime))
            .OnComplete(() => OnAnimEnd?.Invoke());
    }
}
