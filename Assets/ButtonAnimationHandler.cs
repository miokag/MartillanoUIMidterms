using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimationHandler : MonoBehaviour
{
    public Button[] buttons;
    public Image leaf;
    bool isScaled, isFlyDown, isFadeUp, isZoomed;
    private float initialY;

    void Start()
    {
        initialY = leaf.transform.position.y;
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button button)
    {
        var leafsequence = DOTween.Sequence();
        if (button.name == "ScaleButton")
        {
            if(isScaled == false)
            {
                leafsequence.Append(leaf.transform.DOScale(1.5f, 0.5f));
                leafsequence.Join(leaf.DOFade(0f, 0.5f));
                isScaled = true;
            }
            else
            {
                leafsequence.Append(leaf.transform.DOScale(2f, 0.5f));
                leafsequence.Join(leaf.DOFade(1f, 0.5f));
                isScaled = false;
            }
        }

        if (button.name == "ZoomButton")
        {
            if (isZoomed == false)
            {
                leaf.transform.DOScale(0f, 0.2f);
                isZoomed = true;
            }
            else
            {
                leafsequence.Append(leaf.transform.DOScale(2f, 0.2f));
                isZoomed = false;
            }
            
        }

        if (button.name == "FlyDownButton")
        {
            if(isFlyDown == false)
            {
                leaf.transform.DOMoveY(10f, 0.3f).SetEase(Ease.InBack);
                isFlyDown = true;
            }
            else
            {
                leaf.transform.DOMoveY(initialY, 0.3f).SetEase(Ease.OutBack);
                isFlyDown = false;
            }
        }

        if (button.name == "PulseButton")
        {
            leafsequence.Append(leaf.transform.DOScale(1.7f, 0.2f));
            leafsequence.Join(leaf.DOFade(0.5f, 0.2f));
            leafsequence.Append(leaf.transform.DOScale(2f, 0.2f));
            leafsequence.Join(leaf.DOFade(1f, 0.2f));
        }

        if (button.name == "FadeUpButton")
        {
            if (isFadeUp == false)
            {
                leafsequence.Append(leaf.transform.DOMoveY(-0.2f, 0.5f));
                leafsequence.Join(leaf.DOFade(0f, 0.5f));
                isFadeUp = true;
            }
            else
            {
                leafsequence.Append(leaf.transform.DOMoveY(initialY, 0.5f));
                leafsequence.Join(leaf.DOFade(1f, 0.5f));
                isFadeUp = false;
            }
        }

        if (button.name == "FlashButton")
        {
            leafsequence.Append(leaf.DOFade(0f, 0.2f));
            leafsequence.Append(leaf.DOFade(1f, 0.2f));
            leafsequence.Append(leaf.DOFade(0f, 0.2f));
            leafsequence.Append(leaf.DOFade(1f, 0.2f));
        }

    }

}
