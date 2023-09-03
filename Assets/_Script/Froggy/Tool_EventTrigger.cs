using UnityEngine;
using UnityEngine.Events;

public enum AutoCallTiming
{
    None,
    OnAwake,
    OnStart,
    OnEnable,
}

public class Tool_EventTrigger : MonoBehaviour
{
    public AutoCallTiming AutoCall;
    public bool Loop;
    public float AutoCallDelay;
    public UnityEvent Event;

    public void Awake()
    {
        if (AutoCall == AutoCallTiming.OnAwake)
            InvokeEvent();
    }

    public void Start()
    {
        if (AutoCall == AutoCallTiming.OnStart)
            InvokeEvent();
    }

    public void OnEnable()
    {
        if (AutoCall == AutoCallTiming.OnEnable)
            InvokeEvent();
    }

    public virtual void InvokeEvent()
    {
        if (Loop)
            InvokeRepeating("DoEvent", AutoCallDelay, AutoCallDelay);
        else
            Delay.Instance.WaitForSeconds(AutoCallDelay, DoEvent);
    }

    public virtual void DoEvent()
    {
        Event.Invoke();
    }
}