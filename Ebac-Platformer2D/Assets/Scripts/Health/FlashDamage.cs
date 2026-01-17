using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class FlashDamage : MonoBehaviour
{

    public List<SpriteRenderer> spriteRenderers;
    public Color flashColor = Color.red;
    public float duration = 0.3f;

    private Tween _currentTween;

    public void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var s in spriteRenderers)
        {
            s.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flash();
        }
    }
}
