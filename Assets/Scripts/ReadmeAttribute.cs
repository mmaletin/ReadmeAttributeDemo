
// Made by Max Maletin https://github.com/mmaletin

using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// This attribute creates a collapsable text area in the inspector. Use it on serializable variables. Unity RTF tags are supprted.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public class ReadmeAttribute : PropertyAttribute {

    public string name;
    public string value;

    public bool selectable;

    public ReadmeAttribute(string value, bool selectable = false) : this("<b>Readme</b>", value, selectable) { }

    public ReadmeAttribute(string name, string value, bool selectable = false)
    {
        this.name = name;
        this.value = value;

        this.selectable = selectable;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadmeAttribute))]
public class DecoratorReadmeDrawer : DecoratorDrawer
{
    private static GUIStyle invisibleButtonStyle = new GUIStyle();
    private static GUIStyle textAreaStyle = new GUIStyle(GUI.skin.textArea) { richText = true, padding = new RectOffset(10, 10, 10, 10) };
    private static GUIStyle headerStyle = new GUIStyle(EditorStyles.foldout) { richText = true };

    bool groupIsVisible = false;
    float readmeHeight = 0;

    override public void OnGUI(Rect position)
    {
        var readme = attribute as ReadmeAttribute;

        // Readme foldout //

        Rect foldoutLabelRect = new Rect(position.xMin, position.yMin, position.width, readme.selectable ? 16f : GetHeight());

        //Invisible button to catch text clicks
        if (GUI.Button(foldoutLabelRect, "", invisibleButtonStyle))
        {
            groupIsVisible = !groupIsVisible;
        }

        // Readme text //

        groupIsVisible = EditorGUI.Foldout(foldoutLabelRect, groupIsVisible, readme.name, headerStyle);

        if (groupIsVisible)
        {
            GUIContent readmeText = new GUIContent(readme.value);

            readmeHeight = textAreaStyle.CalcHeight(readmeText, position.width);

            Rect textRect = new Rect(position.xMin, position.yMin + 18, position.width, readmeHeight);

            GUI.TextArea(textRect, readme.value, textAreaStyle);
        }
    }

    //Used by Unity to determine element size
    override public float GetHeight()
    {
        return groupIsVisible ? (20f + readmeHeight) : 18f;
    }
}
#endif
