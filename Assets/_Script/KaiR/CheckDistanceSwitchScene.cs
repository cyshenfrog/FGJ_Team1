using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceSwitchScene : MonoBehaviour
{
    [SerializeField] float validDistance_;

    public void StartCheck()
    {
        StartCoroutine(nameof(check));
    }
    IEnumerator check()
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
        Froggy.GoToLevel2();
    }
}
