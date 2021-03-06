﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
 
[InitializeOnLoad]
public class XSStyles : MonoBehaviour
{
    public static string ver = "1.6";

    //Help URLs
    public static string mainURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.xh0nk8x7ws1g";
    public static string normalsURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.j7qze9btrmw8";
    public static string shadowsURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.8l0gi0hntyfs";
    public static string rimlightURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.tpxp2jrhrhxp";
    public static string emissionsURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.zc983jrwb5x4";
    public static string specularURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.gyu8l75mbtdq";
    public static string reflURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.yqzg9axi3gi";
    public static string sssURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.j2nk83f6azph";
    public static string outlineURL = "https://docs.google.com/document/d/1xJ4PID_nwqVm_UCsO2c2gEdiEoWoCGeM_GDK_L8-aZE/edit#bookmark=id.jpaf9t25in8p";

    public static string[] patrons = {"Wandering Youth", "Salt Queen", "Q", "NepsyNeptune", "Kurisu", "xXxEdgeLord69MSxXx"};

    public static string uiPath;
    private static GUISkin skin;

    [UnityEditor.Callbacks.DidReloadScripts]
    private static void setupIconsOnReload()
    {

        uiPath = XSStyles.findAssetPath(uiPath) + "/Editor/Resources/";
        //-----

        skin = (GUISkin)AssetDatabase.LoadAssetAtPath<GUISkin>(uiPath + "XSGuiSkin.guiskin");

        if (skin == null){
            skin = (GUISkin)AssetDatabase.LoadAssetAtPath<GUISkin>(uiPath + "XSGuiSkin.guiskin");
        }

    }

    public static void setupIcons()
    {
        if (skin == null){
            uiPath = XSStyles.findAssetPath(uiPath) + "/Editor/Resources/";
            skin = (GUISkin)AssetDatabase.LoadAssetAtPath<GUISkin>(uiPath + "XSGuiSkin.guiskin");
        }
    }

    public static class Styles
    {
        public static GUIContent version = new GUIContent("XSToon v" + ver, "The currently installed version of XSToon.");
    }
            
    // Labels
    public static void DoHeader(GUIContent HeaderText)
    {
        GUILayout.Label(HeaderText, new GUIStyle(EditorStyles.boldLabel)
        {
            alignment = TextAnchor.MiddleCenter,
            wordWrap = true,
            fontSize = 12
        });
    }

    public static void doLabel(string text)
    {
        GUILayout.Label(text, new GUIStyle(EditorStyles.label)
        {
            alignment = TextAnchor.MiddleCenter,
            wordWrap = true,
            fontSize = 12
        });
    }

    public static void doLabelLeft(string text)
    {
        GUILayout.Label(text, new GUIStyle(EditorStyles.label)
        {
            alignment = TextAnchor.MiddleLeft,
            wordWrap = true,
            fontSize = 12
        });
    }

    public static void doLabelSmall(string text)
    {
        GUILayout.Label(text, new GUIStyle(EditorStyles.label)
        {
            alignment = TextAnchor.MiddleLeft,
            wordWrap = true,
            fontSize = 10
        });
    }
    // ---- 

    static public GUIStyle _LineStyle;
    static public GUIStyle LineStyle
    {
        get
        {
            if (_LineStyle == null)
            {
                _LineStyle = new GUIStyle();
                _LineStyle.normal.background = EditorGUIUtility.whiteTexture;
                _LineStyle.stretchWidth = true;
            }

            return _LineStyle;
        }
    }

    //GUI Buttons
    static public void callGradientEditor()
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.skin = null;
        if (GUILayout.Button("Open Gradient Editor", GUILayout.Width(200), GUILayout.Height(20)))
        {
            XSGradientEditor.Init();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    static public void ResetAdv(Material material)
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.skin = null;
        if (GUILayout.Button("Reset ZTest / ZWrite", GUILayout.Width(200), GUILayout.Height(20)))
        {
            material.SetFloat("_ZTest", 4);
            material.SetFloat("_ZWrite", 1);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    
    static public void ResetAdvAll(Material material)
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.skin = null;
        if (GUILayout.Button("Reset All Advanced", GUILayout.Width(200), GUILayout.Height(20)))
        {
            material.SetFloat("_colormask", 15);
            material.SetFloat("_Stencil", 0);
            material.SetFloat("_StencilComp", 0);
            material.SetFloat("_StencilOp", 0);
            material.SetFloat("_StencilFail", 0);
            material.SetFloat("_StencilZFail", 0);
            material.SetFloat("_ZWrite", 1);
            material.SetFloat("_ZTest", 4);
            material.SetFloat("_UseUV2forNormalsSpecular", 0);
            material.SetFloat("_RampBaseAnchor", 0.5f);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    static public void CallResetAdv(Material material)
    {
            material.SetFloat("_colormask", 15);
            material.SetFloat("_Stencil", 0);
            material.SetFloat("_StencilComp", 0);
            material.SetFloat("_StencilOp", 0);
            material.SetFloat("_StencilFail", 0);
            material.SetFloat("_StencilZFail", 0);
            material.SetFloat("_ZWrite", 1);
            material.SetFloat("_ZTest", 4);
            material.SetFloat("_UseUV2forNormalsSpecular", 0);
            material.SetFloat("_RampBaseAnchor", 0.5f);
    }
    //------

    //Help Box
    public static void HelpBox(string message, MessageType type)
    {
        EditorGUILayout.HelpBox(message, type);
    }

    //GUI Lines
    static public void Separator()
    {
        GUILayout.Space(4);
        GUILine(new Color(.3f, .3f, .3f), 1);
        GUILine(new Color(.9f, .9f, .9f), 1);
        GUILayout.Space(4);
    }

    static public void SeparatorThin()
    {
        GUILayout.Space(2);
        GUILine(new Color(.1f, .1f, .1f), 1f);
        GUILine(new Color(.3f, .3f, .3f), 1f);
        GUILayout.Space(2);
    }

    static public void SeparatorBig()
    {
        GUILayout.Space(10);
        GUILine(new Color(.3f, .3f, .3f), 2);
        GUILayout.Space(1);
        GUILine(new Color(.3f, .3f, .3f), 2);
        GUILine(new Color(.85f, .85f, .85f), 1);
        GUILayout.Space(10);
    }

    static public void GUILine(float height = 2f)
    {
        GUILine(Color.black, height);
    }

    static public void GUILine(Color color, float height = 2f)
    {
        Rect position = GUILayoutUtility.GetRect(0f, float.MaxValue, height, height, LineStyle);

        if (Event.current.type == EventType.Repaint)
        {
            Color orgColor = GUI.color;
            GUI.color = orgColor * color;
            LineStyle.Draw(position, false, false, false, false);
            GUI.color = orgColor;
        }
    }
    // --------------

    //Help Buttons
    public static void helpPopup(string url)//bool showBox, string title, string message, string button)
    {
        GUI.skin = skin;
        if (GUILayout.Button("", "helpButton", GUILayout.Width(16), GUILayout.Height(16)))
        {
            Application.OpenURL(url);
            // showBox = true;
            // if (showBox == true)
            // {
            //     EditorUtility.DisplayDialog(title,
            //                                 message, button);
            // }
        }
    }

    //Find Asset Path
    public static string findAssetPath(string finalFilePath)
    {
        string[] guids1 = AssetDatabase.FindAssets("XSShaderGenerator", null);
        string untouchedString = AssetDatabase.GUIDToAssetPath(guids1[0]);
        string[] splitString = untouchedString.Split('/');

        ArrayUtility.RemoveAt(ref splitString, splitString.Length - 1);
        ArrayUtility.RemoveAt(ref splitString, splitString.Length - 1);

        finalFilePath = string.Join("/", splitString);
        return finalFilePath;
    }


    //exrta buttons
    public static void githubButton(int Width, int Height)
    {
        GUI.skin = skin;
        if (GUILayout.Button("", "github", GUILayout.Width(Width), GUILayout.Height(Height)))
        {
            Application.OpenURL("https://github.com/Xiexe");
        }
    }

    public static void discordButton(int Width, int Height)
    {
        GUI.skin = skin;
        if (GUILayout.Button("", "discord", GUILayout.Width(Width), GUILayout.Height(Height)))
        {
            Application.OpenURL("https://discord.gg/M6MGNnT");
        }

    }

    public static void patreonButton(int Width, int Height)
    {
        GUI.skin = skin;
        if (GUILayout.Button("", "patreon", GUILayout.Width(Width), GUILayout.Height(Height)))
        {
            Application.OpenURL("https://www.patreon.com/xiexe");
        }
    }
    
}
