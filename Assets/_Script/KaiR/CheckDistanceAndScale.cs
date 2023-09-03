using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace KaiR
{
    public class CheckDistanceAndScale : MonoBehaviour
    {
        [Header("RequiredComponent")]
        [SerializeField] ZoomInOut zoomInOut_;
        [SerializeField] DragRoot dragRoot_;

        [Header("UnityEvent")]
        [SerializeField] UnityEvent validEvent_;
        [SerializeField] UnityEvent invalidEvent_;

        [Header("ValidValue")]
        [SerializeField] [Min(0)] float validDistance_;
        [SerializeField] [Min(0)] float validScale_;

        [Header("Curve")]
        [SerializeField] AnimationCurve alterCurve_;

        public event EventHandler ValidEvent;
        public event EventHandler InvalidEvent;

        bool isValid_ = false;

        public float PositivePercent
        {
            get
            {
                float scalePercent = Mathf.Clamp01(transform.lossyScale.x / validScale_);
                float distancePercent = Mathf.Clamp01(validDistance_ / Vector2.Distance(transform.position, Vector2.zero));
                return (scalePercent + distancePercent) / 2;
            }
        }
        public float AlterPercent
        {
            get
            {
                return alterCurve_.Evaluate(PositivePercent);
            }
        }

        void Start()
        {
            zoomInOut_.ZoomInEvent += check;
            zoomInOut_.ZoomOutEvent += check;
            dragRoot_.DragEvent += check;
        }

        void check(object sender, EventArgs eventArgs)
        {
            if (Mathf.Approximately(PositivePercent, 1) && !isValid_)
            {
                isValid_ = true;
                validEvent_.Invoke();
                ValidEvent?.Invoke(this, EventArgs.Empty);
            }
            else if (!Mathf.Approximately(PositivePercent, 1) && isValid_)
            {
                isValid_ = false;
                invalidEvent_.Invoke();
                InvalidEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Unsubscribe()
        {
            zoomInOut_.ZoomInEvent -= check;
            zoomInOut_.ZoomOutEvent -= check;
            dragRoot_.DragEvent -= check;
        }
    }
}

