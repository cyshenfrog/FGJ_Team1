using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiR
{
    public class DragRoot : MonoBehaviour
    {
        [SerializeField] Transform rootObjTrans_;

        Camera mainCamera_;

        bool midBtnDown_ = false;

        void Start()
        {
            mainCamera_ = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                midBtnDown_ = true;
                StartCoroutine(nameof(moveRoot));
            }
            if (Input.GetMouseButtonUp(2))
            {
                midBtnDown_ = false;
            }
        }

        IEnumerator moveRoot()
        {
            Vector3 previousPos = mainCamera_.ScreenToWorldPoint(Input.mousePosition);
            previousPos.Set(previousPos.x, previousPos.y, 0);
            while (midBtnDown_)
            {
                Vector3 currentPos = mainCamera_.ScreenToWorldPoint(Input.mousePosition);
                currentPos.Set(currentPos.x, currentPos.y, 0);
                rootObjTrans_.position += currentPos - previousPos;
                previousPos = currentPos;
                yield return null;
            }
        }
    }
}
