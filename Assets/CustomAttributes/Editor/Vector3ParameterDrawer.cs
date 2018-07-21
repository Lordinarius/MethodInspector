using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Vector3ParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = Vector3.zero;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.Vector3Field(ObjectNames.NicifyVariableName(propertyInfo.Name), (Vector3)param);
    }
}

