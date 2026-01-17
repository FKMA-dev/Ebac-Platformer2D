using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{

    public List<GameObject> myButtons;

    [Header("Animation")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;
    public Vector2 scaleValue = new Vector2(1f, 1f);

    private void Awake()
    {
        HideAllButtons();
        ShowButton();
    }

    private void HideAllButtons()
    {
        foreach (var b in myButtons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButton()
    {
        for (int i = 0; i < myButtons.Count; i++)
        {
            var b = myButtons[i];
            b.SetActive(true);
            b.transform.DOScale(scaleValue, duration).SetDelay(delay).SetEase(ease);
        }
    }

}
