using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaiR
{
    public class SetCursorState : MonoBehaviour
    {
        public void SetCursorTexture(Texture2D texture2D)
        {
            Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

