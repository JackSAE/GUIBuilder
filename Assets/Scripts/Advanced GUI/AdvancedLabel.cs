using UnityEngine;
 
public static class AdvancedLabel
{
    public static void Draw(Rect r, string txt, params ILabelParameter[] parameters) { Draw(r, new GUIContent(txt), GUI.skin.label, parameters); }
    public static void Draw(Rect r, Texture2D tex, params ILabelParameter[] parameters) { Draw(r, new GUIContent(tex), GUI.skin.label, parameters); }
    public static void Draw(Rect r, GUIContent content, params ILabelParameter[] parameters) { Draw(r, content, GUI.skin.label, parameters); }
    public static void Draw(Rect r, string txt, GUIStyle style, params ILabelParameter[] parameters) { Draw(r, new GUIContent(txt), style, parameters); }
    public static void Draw(Rect r, Texture2D tex, GUIStyle style, params ILabelParameter[] parameters) { Draw(r, new GUIContent(tex), style, parameters); }
    public static void Draw(Rect r, GUIContent content, GUIStyle style, params ILabelParameter[] parameters)
    {
        foreach( ILabelParameter L in parameters )
            L.Update(style);
 
        GUI.Label(r, content, style);
 
        foreach( ILabelParameter L in parameters )
            L.Backup(style);
    }
 
    public static void DrawLayout(string txt, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(txt), GUI.skin.label, null, parameters); }
    public static void DrawLayout(Texture2D tex, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(tex), GUI.skin.label, null, parameters); }
    public static void DrawLayout(GUIContent content, params ILabelParameter[] parameters) { DrawLayout(content, GUI.skin.label, null, parameters); }
    public static void DrawLayout(string txt, GUIStyle style, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(txt), style, null, parameters); }
    public static void DrawLayout(Texture2D tex, GUIStyle style, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(tex), style, null, parameters); }
    public static void DrawLayout(GUIContent content, GUIStyle style, params ILabelParameter[] parameters) { DrawLayout(content, style, null, parameters); }
    public static void DrawLayout(string txt, GUILayoutOption[] options, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(txt), GUI.skin.label, options, parameters); }
    public static void DrawLayout(Texture2D tex, GUILayoutOption[] options, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(tex), GUI.skin.label, options, parameters); }
    public static void DrawLayout(GUIContent content, GUILayoutOption[] options, params ILabelParameter[] parameters) { DrawLayout(content, GUI.skin.label, options, parameters); }
    public static void DrawLayout(string txt, GUIStyle style, GUILayoutOption[] options, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(txt), style, options, parameters); }
    public static void DrawLayout(Texture2D tex, GUIStyle style, GUILayoutOption[] options, params ILabelParameter[] parameters) { DrawLayout(new GUIContent(tex), style, options, parameters); }
    public static void DrawLayout(GUIContent content, GUIStyle style, GUILayoutOption[] options, params ILabelParameter[] parameters)
    {
        foreach( ILabelParameter L in parameters )
            L.Update(style);
 
        GUILayout.Label(content, style, options);
 
        foreach( ILabelParameter L in parameters )
            L.Backup(style);
    }
}
 
 
public interface ILabelParameter
{
    void Backup(GUIStyle style);
    void Update(GUIStyle style);
}
 
 
public class NewFont : ILabelParameter
{
    Font font, backupFont;
    public NewFont(Font _font) { font = _font; }
    public void Backup(GUIStyle style) { style.font = backupFont; }
    public void Update(GUIStyle style) { backupFont = style.font; style.font = font; }
}
 
public class NewFontSize : ILabelParameter
{
    int fontSize, backupFontSize;
    public NewFontSize(int _fontSize) { fontSize = _fontSize;  }
    public void Backup(GUIStyle style) { style.fontSize = backupFontSize; }
    public void Update(GUIStyle style) { backupFontSize = style.fontSize; style.fontSize = fontSize; }
}
 
public class NewFontStyle : ILabelParameter
{
    FontStyle fontStyle, backupFontStyle;
    public NewFontStyle(FontStyle _fontStyle) { fontStyle = _fontStyle; }
    public void Backup(GUIStyle style) { style.fontStyle = backupFontStyle; }
    public void Update(GUIStyle style) { backupFontStyle = style.fontStyle; style.fontStyle = fontStyle; }
}
 
public class NewColor : ILabelParameter
{
    Color color, backupColor;
    public NewColor(Color _color) { color = _color; }
    public void Backup(GUIStyle style) { GUI.color = backupColor; }
    public void Update(GUIStyle style) { backupColor = GUI.color; GUI.color = color; }
}
 
public class NewAlignement : ILabelParameter
{
    TextAnchor alignment, backupAlignment;
    public NewAlignement(TextAnchor _alignment) { alignment = _alignment; }
    public void Backup(GUIStyle style) { style.alignment = backupAlignment; }
    public void Update(GUIStyle style) { backupAlignment = style.alignment; style.alignment = alignment; }
}