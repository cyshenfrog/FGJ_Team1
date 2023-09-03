using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaiR
{
    public class StartBtnClick : MonoBehaviour
    {
        [SerializeField] ZoomInOut zoomInOut_;
        [SerializeField] GameObject loadingImgObj_;
        [SerializeField] float delayEventWaitTime_;

        [SerializeField] UnityEvent delayEvent_;

        public void Click()
        {
            zoomInOut_.SetZoomMode(ZoomMode.ChaseObj);
            loadingImgObj_.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            loadingImgObj_.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(nameof(delayInvokeEvent));
        }

        IEnumerator delayInvokeEvent()
        {
            float duration = 0f;
            while (duration < delayEventWaitTime_)
            {
                duration += Time.deltaTime;
                yield return null;
            }
            delayEvent_.Invoke();
        }
    }
}
