using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MARIOBGM : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void OnEnable()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = 0f;
        m_AudioSource.DOFade(.5f, 5);
    }
}