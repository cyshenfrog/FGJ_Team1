using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KaiR
{
    public class CtrlImgAlfaByDistanceAndScale : MonoBehaviour
    {
        [SerializeField] CheckDistanceAndScale checkDistanceAndScale_;

        Image img_;

        void Start()
        {
            img_ = GetComponent<Image>();
        }

        void Update()
        {
            img_.color = Color.black * checkDistanceAndScale_.AlterPercent;
        }
    }
}

