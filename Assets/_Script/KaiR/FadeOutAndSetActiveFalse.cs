using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KaiR
{
    public class FadeOutAndSetActiveFalse : MonoBehaviour
    {
        [SerializeField] float fadeOutTime_;
        [SerializeField] UnityEvent endEvent_;

        SpriteRenderer spriteRenderer;

        float fadeOutSpd_;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            fadeOutSpd_ = 1 / fadeOutTime_;
        }

        void Update()
        {
            spriteRenderer.color -= Color.black * fadeOutSpd_ * Time.deltaTime;
            if (spriteRenderer.color.a <= 0)
            {
                endEvent_.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

