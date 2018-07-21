using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

[CustomEditor(typeof(MonoBehaviour),true)]
public class ButtonAttributeEditor : Editor {

    public List<InspectButtonAttribute> buttonAttributes;
    private static readonly Dictionary<Type, MethodParameterDrawer> MethodParameterDrawers;

    static ButtonAttributeEditor() {
        MethodParameterDrawers = new Dictionary<Type,MethodParameterDrawer> {
            { typeof(float)     , new FloatParameterDrawer() },
            { typeof(double)    , new DoubleParameterDrawer() },
            { typeof(int)       , new IntParameterDrawer() },
            { typeof(long)      , new LongParameterDrawer() },
            { typeof(Enum)      , new EnumParameterDrawer() },
            { typeof(Vector2)   , new Vector2ParameterDrawer() },
            { typeof(Vector3)   , new Vector3ParameterDrawer() },
        };
    }

    private void OnEnable() {
        buttonAttributes = new List<InspectButtonAttribute>();
        var methods = target.GetType().GetMethods();
        foreach(var item in methods) {
            var a = item.GetCustomAttributes(typeof(InspectButtonAttribute), false).Cast<InspectButtonAttribute>().ToArray();
            if(a.Length > 0) {
                var at = a[0];
                if(at.buttonName == InspectButtonAttribute.DefaultButtonNameKey) {
                    at.buttonName = item.Name;
                }
                at.methodInfo = item;
                var parameters = item.GetParameters();
                at.properties = new object[parameters.Length];
                for(int i = 0; i < parameters.Length; i++) {
                    var param = parameters[i];
                    MethodParameterDrawer drawer;
                    Type parameterType = param.ParameterType;
                    Type parentType = parameterType.BaseType;
                    if(MethodParameterDrawers.TryGetValue(parameterType,out drawer)) {
                        drawer.InitializeParameter(ref at.properties[i],param);
                    }
                    else if (parentType != null && MethodParameterDrawers.TryGetValue(parentType, out drawer)) {
                        drawer.InitializeParameter(ref at.properties[i],param);
                    }
                    else {
                        Debug.LogWarning("Can not find initializer for defined type: " + parameterType);
                    }
                }
                buttonAttributes.Add(a[0]);
            }
        }
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(buttonAttributes != null && buttonAttributes.Count > 0) {
            foreach(var item in buttonAttributes) {
                //Skip disabled visibilities
                if ((item.visibilityMode == InspectButtonAttribute.VisibilityMode.EditModeOnly && Application.isPlaying) ||
                    (item.visibilityMode == InspectButtonAttribute.VisibilityMode.PlayModeOnly &&
                     !Application.isPlaying)) continue;
                
                EditorGUILayout.Space();
                ParameterInfo[] parameters = item.methodInfo.GetParameters();
                bool initiateRect = parameters.Length > 0;
                EditorGUILayout.BeginHorizontal();
                if (initiateRect) {
                    EditorGUILayout.BeginVertical(GUI.skin.box);                    
                }
                if(parameters.Length > 0) {
                    for(int i = 0; i < parameters.Length; i++) {
                        ParameterInfo param = parameters[i];
                        MethodParameterDrawer drawer;
                        Type parameterType = param.ParameterType;
                        Type parentType = parameterType.BaseType;
                        if(MethodParameterDrawers.TryGetValue(parameterType, out drawer)) {
                            drawer.DrawParameter(ref item.properties[i], param);
                        }
                        else if (parentType != null && MethodParameterDrawers.TryGetValue(parentType, out drawer)) {
                            drawer.DrawParameter(ref item.properties[i], param);
                        }
                        else {
                            Debug.LogWarning("Can not find drawer for defined type: " + parameterType);
                        }
                    }
                }
                if (initiateRect) {
                    EditorGUILayout.EndVertical();              
                }
                if(GUILayout.Button(item.buttonName)) {
                    item.methodInfo.Invoke(target, item.properties);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
