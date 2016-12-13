using UnityEngine;
using System.Collections;

//http://wiki.unity3d.com/index.php/Custom_Mouse_Pointer
//Useage -> Attach this script to any gameObject you want, preferable a new empty one. Assign your custom Texture to the script.

public class mousePointer : MonoBehaviour
{
    public Texture2D cursorImage;

    private int cursorWidth = 32;
    private int cursorHeight = 32;

    void Start()
    {
        Cursor.visible = false;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, cursorWidth, cursorHeight), cursorImage);
    }
}