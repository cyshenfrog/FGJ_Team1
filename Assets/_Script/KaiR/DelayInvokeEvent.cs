using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayInvokeEvent : MonoBehaviour
{
    [SerializeField] float delayTime_;
    [SerializeField] UnityEvent delayEvent_;

    public void StartDelay()
    {
        StartCoroutine(nameof(delayInvoke));
    }
    IEnumerator delayInvoke()
    {
        float duration = 0f;
        while (duration < delayTime_)
        {
            duration += Time.deltaTime;
            yield return null;
        }
        delayEvent_.Invoke();
    }
}
