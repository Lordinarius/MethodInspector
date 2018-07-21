using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Vector2ParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = Vector2.zero;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.Vector2Field(ObjectNames.NicifyVariableName(propertyInfo.Name), (Vector2)param);
    }
}

