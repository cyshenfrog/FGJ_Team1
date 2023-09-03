using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace KaiR
{
    public class TypewriterEffect : MonoBehaviour
    {
        [SerializeField] float startWaitTime_;
        [SerializeField] float charsPerSec_;
        [SerializeField] [TextArea] string words_;

        TextMeshProUGUI txt_;

        int currentPos_ = 0;

        void OnEnable()
        {
            StartCoroutine(nameof(typewriter));
        }

        void Start()
        {
            txt_ = GetComponent<TextMeshProUGUI>();
        }

        IEnumerator typewriter()
        {
            float duration = 0f;
            while (duration < startWaitTime_)
            {
                duration += Time.deltaTime;
                yield return null;
            }

            while (currentPos_ <= words_.Length)
            {
                txt_.text = words_.Substring(0, currentPos_);
                currentPos_++;

                duration = 0f;
                while (duration < charsPerSec_ && currentPos_ <= words_.Length)
                {
                    duration += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}

