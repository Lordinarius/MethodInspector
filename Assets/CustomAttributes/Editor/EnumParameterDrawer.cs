using System;
using System.Reflection;
using UnityEditor;

public class EnumParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        Array enumValues = Enum.GetValues(propertyInfo.ParameterType);
        param = enumValues.GetValue(0);
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.EnumPopup(ObjectNames.NicifyVariableName(propertyInfo.Name), (Enum)param);
    }
}

