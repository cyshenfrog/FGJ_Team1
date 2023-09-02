using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Tool_ClickArea2D : MonoBehaviour
{
    public UnityEvent ClickEvent;
    public UnityEvent DownEvent;
    public UnityEvent HoldEvent;
    public UnityEvent UpEvent;
    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;
    public UnityEvent StayEvent;
    private bool isDown = false;

    private void Update()
    {
        if (isDown)
            HoldEvent.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        ClickEvent.Invoke();
    }

    private void OnMouseDown()
    {
        isDown = true;
        DownEvent.Invoke();
    }

    private void OnMouseUp()
    {
        isDown = false;
        UpEvent.Invoke();
    }

    private void OnMouseExit()
    {
        ExitEvent.Invoke();
    }

    private void OnMouseOver()
    {
        StayEvent.Invoke();
    }

    private void OnMouseEnter()
    {
        EnterEvent.Invoke();
    }
}