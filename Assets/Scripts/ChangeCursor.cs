using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D flecha;
    public Texture2D mira;
    public bool menuActive;

    void Start()
    {
        if (menuActive)
        {
            Cursor.SetCursor(flecha, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(mira, new Vector2 (256, 256), CursorMode.Auto);
        }
    }
}
