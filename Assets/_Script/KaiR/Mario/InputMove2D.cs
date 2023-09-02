using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KaiR
{
    public class InputMove2D : MonoBehaviour
    {
        [SerializeField] float moveSpd_;

        [SerializeField] Transform leftTrans_;
        [SerializeField] Transform rightTrans_;

        [SerializeField] string horizontalName_;

        public event EventHandler GetTreasureEvent;

        readonly Vector3 ORIGIN_ROT = Vector3.zero;
        readonly Vector3 FLIP_ROT = new(0, 180, 0);

        void Update()
        {
            float horizontal = Input.GetAxisRaw(horizontalName_);
            switch (horizontal)
            {
                case > 0:
                    transform.eulerAngles = ORIGIN_ROT;
                    break;
                case < 0:
                    transform.eulerAngles = FLIP_ROT;
                    break;
            }
            transform.Translate(moveSpd_ * Time.deltaTime * transform.right * horizontal);
            if (transform.position.x <= leftTrans_.position.x)
            {
                transform.position = new(leftTrans_.position.x, transform.position.y, 0);
            }
            if (transform.position.x >= rightTrans_.position.x)
            {
                GetTreasureEvent?.Invoke(this, EventArgs.Empty);
                this.enabled = false;
            }
        }
    }
}
