using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckDistanceSwitchScene : MonoBehaviour
{
    [SerializeField] private float validDistance_;
    public UnityEvent endEvent1;
    public UnityEvent endEvent;

    public void StartCheck()
    {
        StartCoroutine(nameof(check));
    }

    private IEnumerator check()
    {
        while (Vector2.Distance(transform.position, Vector2.zero) > validDistance_)
        {
            yield return null;
        }
        float duration = 0f;
        while (duration < 1)
        {
            duration += Time.deltaTime;
            yield return null;
        }
        endEvent1.Invoke();
        yield return new WaitForSeconds(.5f);
        endEvent.Invoke();
        yield return new WaitForSeconds(2);
        Froggy.GoToLevel2();
    }
}