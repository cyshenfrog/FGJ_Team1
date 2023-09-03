using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyClick : MonoBehaviour
{
    public static int EnergyCount = 0;
    public SpriteRenderer ClickSprite;
    public GameObject Energy;
    public Transform[] Corners;

    private void OnMouseEnter()
    {
        ClickSprite.DOKill();
        ClickSprite.DOFade(0.15f, 0.1f);
    }

    private void OnMouseExit()
    {
        ClickSprite.DOKill();
        ClickSprite.DOFade(0f, 0.1f);
    }

    private void OnMouseDown()
    {
        ClickSprite.DOKill();
        ClickSprite.DOFade(0.1f, 0.1f);
        if (EnergyCount >= 10)
            return;
        Stage2.Instance.ClickSE.pitch = 1 + EnergyCount * 0.1f;
        Stage2.Instance.ClickSE.Play();
        EnergyCount++;
        if (EnergyCount == 10)
        {
            _OnEnergyFull();
        }
        GameObject p = Instantiate(Energy, transform.position, Quaternion.identity);
        LoopPathTween(p.transform);
    }

    private void OnMouseUp()
    {
        ClickSprite.DOKill();
        ClickSprite.DOFade(0.15f, 0.1f);
    }

    private void LoopPathTween(Transform target)
    {
        StartCoroutine(_LoopPathTween(target));
    }

    private IEnumerator _LoopPathTween(Transform target)
    {
        for (int i = 0; i < Corners.Length; i++)
        {
            target.DOMove(Corners[i].position, 1f)
                .SetDelay(i);
        }
        yield return new WaitForSeconds(4);
        LoopPathTween(target);
    }

    private void _OnEnergyFull()
    {
        Stage2.Instance.OnEnergyFull();
    }
}