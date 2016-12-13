using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//http://wiki.unity3d.com/index.php/AdvancedButton

public enum AdvancedButtonResult
{
    SimpleClick,
    DoubleClick,
    Drag,
    Drop,
    None
}

public class AdvancedButton
{
    public AdvancedButton(float delayMin, float delayMax, float delayDrag)
    {
        hitMin = delayMin;
        hitMax = delayMax;
        dragDelay = delayDrag;
        isHover = false;
    }

    private float hitMin, hitMax, dragDelay;
    private float lastHit, lastMouseDown;
    private bool isHover;
    private Rect rect;

    // Count the number of click
    private AdvancedButtonResult HandleClickCount(float t)
    {
        // First hit
        if (lastHit < 0f || t > hitMax)
        {
            lastHit = Time.time;
            return AdvancedButtonResult.SimpleClick;
        }
        // Second hit, we test the delay
        else if (t >= hitMin && t < hitMax)
        {
            lastHit = -1f;
            return AdvancedButtonResult.DoubleClick;
        }

        return AdvancedButtonResult.None;
    }

    // Return true when you press the mouse over a button a stay over it long enough whilst pressing.
    private AdvancedButtonResult HandleDragAndDrop(float t)
    {
        Event e = Event.current;
        if (e.isMouse)
        {
            if (e.button == 0)
            {
                // Mouse Up, cancel drag
                if (e.type == EventType.mouseUp)
                {
                    bool wasPressed = lastMouseDown > 0f;
                    lastMouseDown = -1f;
                    if (!wasPressed && isHover)
                        return AdvancedButtonResult.Drop;
                }
                // Mouse Down
                else if (e.type == EventType.mouseDown)
                {
                    // Over the button
                    if (isHover)
                    {
                        t = -dragDelay;
                        lastMouseDown = Time.time;
                    }
                }
            }
        }

        // If we are holding the mouse
        if (lastMouseDown > 0f)
        {
            // Make sure we don't leave the button
            if (isHover)
            {
                // We've hold long enough
                if (t > dragDelay)
                    return AdvancedButtonResult.Drag;
            }
            // We left the button, cancel
            else
                lastMouseDown = -1f;
        }

        return AdvancedButtonResult.None;
    }

    // Usual GUI functions
    public AdvancedButtonResult Draw(Rect r, string txt) { return Draw(r, new GUIContent(txt), GUI.skin.button); }
    public AdvancedButtonResult Draw(Rect r, Texture2D tex) { return Draw(r, new GUIContent(tex), GUI.skin.button); }
    public AdvancedButtonResult Draw(Rect r, GUIContent content) { return Draw(r, content, GUI.skin.button); }
    public AdvancedButtonResult Draw(Rect r, string txt, GUIStyle style) { return Draw(r, new GUIContent(txt), style); }
    public AdvancedButtonResult Draw(Rect r, Texture2D tex, GUIStyle style) { return Draw(r, new GUIContent(tex), style); }
    public AdvancedButtonResult Draw(Rect r, GUIContent content, GUIStyle style)
    {
        // The drag test must be performed before the drawing, or events will be eaten.
        isHover = r.Contains(Event.current.mousePosition);
        AdvancedButtonResult dragoDropResult = HandleDragAndDrop(Time.time - lastMouseDown);

        // The usual button
        bool click = GUI.Button(r, content, style);

        if (dragoDropResult != AdvancedButtonResult.None)
            return dragoDropResult;

        if (click)
            return HandleClickCount(Time.time - lastHit);

        return AdvancedButtonResult.None;
    }


    // Usual GUILayout functions
    public AdvancedButtonResult DrawLayout(string txt, params GUILayoutOption[] options) { return DrawLayout(new GUIContent(txt), GUI.skin.button, options); }
    public AdvancedButtonResult DrawLayout(Texture2D tex, params GUILayoutOption[] options) { return DrawLayout(new GUIContent(tex), GUI.skin.button, options); }
    public AdvancedButtonResult DrawLayout(GUIContent content, params GUILayoutOption[] options) { return DrawLayout(content, GUI.skin.button, options); }
    public AdvancedButtonResult DrawLayout(string txt, GUIStyle style, params GUILayoutOption[] options) { return DrawLayout(new GUIContent(txt), style, options); }
    public AdvancedButtonResult DrawLayout(Texture2D tex, GUIStyle style, params GUILayoutOption[] options) { return DrawLayout(new GUIContent(tex), style, options); }
    public AdvancedButtonResult DrawLayout(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
    {
        // The drag test must be performed before the drawing, or events will be eaten.
        AdvancedButtonResult dragoDropResult = dragoDropResult = HandleDragAndDrop(Time.time - lastMouseDown);

        // The usual button
        bool click = GUILayout.Button(content, style, options);

        if (Event.current.type == EventType.Repaint)
        {
            // If repaint, we update the isHover
            rect = GUILayoutUtility.GetLastRect();
            isHover = rect.Contains(Event.current.mousePosition);
        }

        if (dragoDropResult != AdvancedButtonResult.None)
            return dragoDropResult;

        if (click)
            return HandleClickCount(Time.time - lastHit);

        return AdvancedButtonResult.None;
    }
}