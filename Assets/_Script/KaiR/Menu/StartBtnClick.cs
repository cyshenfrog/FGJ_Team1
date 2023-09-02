using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiR
{
    public class StartBtnClick : MonoBehaviour
    {
        [SerializeField] ZoomInOut zoomInOut;
        [SerializeField] GameObject loadingImgObj;

        public void Click()
        {
            zoomInOut.SetZoomMode(ZoomMode.ChaseObj);
            loadingImgObj.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            loadingImgObj.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
