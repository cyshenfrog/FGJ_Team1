using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KaiR
{
    public class FadeOutImgAndSetActiveFalse : MonoBehaviour
    {
        [SerializeField] float fadeOutTime_;
        [SerializeField] UnityEvent endEvent_;

        Image img_;

        float fadeOutSpd_;

        void Start()
        {
            img_ = GetComponent<Image>();

            fadeOutSpd_ = 1 / fadeOutTime_;
        }

        void Update()
        {
            img_.color -= Color.black * fadeOutSpd_ * Time.deltaTime;
            if (img_.color.a <= 0)
            {
                endEvent_.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

