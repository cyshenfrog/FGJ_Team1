using System;
using System.Collections;
using UnityEngine;

public class Delay : UnitySingleton_DR<Delay>
{
    public Coroutine WaitForSeconds(float second, Action callback, bool ignoreTimescale = false)
    {
        return StartCoroutine(d());
        IEnumerator d()
        {
            if (ignoreTimescale)
                yield return new WaitForSecondsRealtime(second);
            else
                yield return new WaitForSeconds(second);
            callback?.Invoke();
        }
    }
}