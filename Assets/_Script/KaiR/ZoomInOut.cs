using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaiR
{
    public class ZoomInOut : MonoBehaviour
    {
        [SerializeField] Transform chaseObjTrans_;
        [SerializeField] Transform zoomCenterTrans_;
        [SerializeField] Transform rootObjTrans_;
        [SerializeField] float minZoomAmount_;

        [Header("InputName")]
        [SerializeField] string mouseScrollWheelName_;

        public event EventHandler ZoomInEvent;
        public event EventHandler ZoomOutEvent;

        Camera mainCamera_;

        ZoomMode zoomMode_ = ZoomMode.ChaseCursor;

        void Start()
        {
            mainCamera_ = Camera.main;
        }

        void Update()
        {
            if (Input.GetAxis(mouseScrollWheelName_) != 0)
            {
                switch (zoomMode_)
                {
                    case ZoomMode.ChaseCursor:
                        Vector3 cursorPos = mainCamera_.ScreenToWorldPoint(Input.mousePosition);
                        cursorPos.Set(cursorPos.x, cursorPos.y, 0);
                        zoomCenterTrans_.position = cursorPos;
                        break;
                    case ZoomMode.ChaseObj:
                        zoomCenterTrans_.position = chaseObjTrans_.position;
                        break;
                }
                rootObjTrans_.SetParent(zoomCenterTrans_);
                float scrollWheelAxis = Input.GetAxis(mouseScrollWheelName_);
                float zoomAmount = Mathf.Clamp(zoomCenterTrans_.localScale.x / 10, minZoomAmount_, Mathf.Infinity);
                switch (scrollWheelAxis)
                {
                    case > 0:
                        zoomCenterTrans_.localScale += Vector3.one * zoomAmount;
                        ZoomInEvent?.Invoke(this, EventArgs.Empty);
                        break;
                    case < 0:
                        zoomCenterTrans_.localScale -= Vector3.one * zoomAmount;
                        if (zoomCenterTrans_.localScale.x < 1)
                        {
                            zoomCenterTrans_.localScale = Vector3.one;
                        }
                        ZoomOutEvent?.Invoke(this, EventArgs.Empty);
                        break;
                }
                rootObjTrans_.SetParent(null);
            }
        }

        public void SetZoomMode(ZoomMode setZoomMode)
        {
            zoomMode_ = setZoomMode;
        }
        public void SetChaseCursor()
        {
            zoomMode_ = ZoomMode.ChaseCursor;
        }
    }

    public enum ZoomMode
    {
        ChaseCursor,
        ChaseObj
    }
}
