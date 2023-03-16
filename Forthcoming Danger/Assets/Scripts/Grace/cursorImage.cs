using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorImage : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        float hsX = cursorTexture.width / 2;
        float hsY = cursorTexture.height / 2;
        Vector2 hotSpot = new Vector2(hsX,hsY);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}    