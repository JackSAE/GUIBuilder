using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is a GUIBuilder Script thats goal is to make working with GUI as easy as UI.


public class GUIBuilder : MonoBehaviour {

    private AdvancedButton advButton;

    public Rect windowRect = new Rect(20, 20, 120, 50);

    public float hSliderValue = 0.0F;

    public float hSbarValue = 0.0F;

    public Texture aTexture;

    public string passwordToEdit = "My Password";

    public string stringToEdit = "Hello World\nI've got 2 lines...";

    public string stringToEditText = "Hello World";

    private bool toggleTxt = false;
    private bool toggleImg = false;

    public int toolbarInt = 0;
    public string[] toolbarStrings = new string[] { "Toolbar1", "Toolbar2", "Toolbar3" };

    public float vSbarValue;

    public float vSliderValue = 0.0F;

    void Awake()
    {

        advButton = new AdvancedButton(0.1f, 0.3f, 1f);
    }

    void OnGUI()
    {

        #region AdvancedButton Example
        AdvancedButtonResult result = advButton.Draw(new Rect(100, 100, 200, 100), "Advanced Button");

        if (result == AdvancedButtonResult.SimpleClick)
            print("Simple click");
        else if (result == AdvancedButtonResult.DoubleClick)
            print("Double click !");
        else if (result == AdvancedButtonResult.Drag)
            print("Dragging !!");
        else if (result == AdvancedButtonResult.Drop)
            print("DROP !!!");
        #endregion

        #region Advanced Label

        GUILayout.BeginArea(new Rect(20,20,100,100));
        AdvancedLabel.DrawLayout("Big size", new GUILayoutOption[] { GUILayout.MinHeight(30) }, new NewFontSize(18), new NewColor(Color.yellow));
        AdvancedLabel.DrawLayout("Small size", new NewFontSize(12));
        GUILayout.EndArea();
        #endregion

        #region Animated Label
        //Turn the animated Script into a function call
        #endregion

        #region Window GUi
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
        #endregion

        #region Box GUi
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
        #endregion

        #region Button GUi
        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
            Debug.Log("Clicked the button with text");
        #endregion
        
         #region DrawTexture GUi
        GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
        #endregion

        #region HorizontalScrollbar GUi
        hSbarValue = GUI.HorizontalScrollbar(new Rect(25, 25, 100, 30), hSbarValue, 1.0F, 0.0F, 10.0F);
        #endregion
        
        #region HorizontalSlider GUi
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 10.0F);
        #endregion

        #region Label GUi
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
        #endregion

        #region PasswordField GUi
        passwordToEdit = GUI.PasswordField(new Rect(10, 10, 200, 20), passwordToEdit, "*"[0], 25);
        #endregion

        #region TextArea GUi
        stringToEdit = GUI.TextArea(new Rect(10, 10, 200, 100), stringToEdit, 200);
        #endregion

        #region TextField GUi
        stringToEditText = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        #endregion

        #region Toggle GUi
        toggleTxt = GUI.Toggle(new Rect(10, 10, 100, 30), toggleTxt, "A Toggle text");
        toggleImg = GUI.Toggle(new Rect(10, 50, 50, 50), toggleImg, aTexture);
        #endregion

        #region Toolbar GUi
        toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings);
        #endregion

        #region VerticalScrollbar GUi
        vSbarValue = GUI.VerticalScrollbar(new Rect(25, 25, 100, 30), vSbarValue, 1.0F, 10.0F, 0.0F);
        #endregion

        #region VerticalSlider GUi
        vSliderValue = GUI.VerticalSlider(new Rect(25, 25, 100, 30), vSliderValue, 10.0F, 0.0F);
        #endregion

    }

    void DoMyWindow(int windowID) {
        GUI.DragWindow(new Rect(0, 0, 10000, 2000));
    }
}
