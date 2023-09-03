using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaiR
{
    public class MoveToTargetPos : MonoBehaviour
    {
        [SerializeField] Vector2 targetPos_;
        [SerializeField] float moveTime_;
        [SerializeField] UnityEvent moveEndEvent_;

        float moveSpd_;
        float duration_;
        
        void OnEnable()
        {
            moveSpd_ = Vector2.Distance(targetPos_, transform.position) / moveTime_;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos_, moveSpd_ * Time.deltaTime);
            duration_ += Time.deltaTime;
            if (duration_ >= moveTime_)
            {
                moveEndEvent_.Invoke();
                this.enabled = false;
            }
        }
    }
}

