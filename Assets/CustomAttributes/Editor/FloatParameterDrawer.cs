using System.Reflection;
using UnityEditor;

public class FloatParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = 0f;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.FloatField(ObjectNames.NicifyVariableName(propertyInfo.Name), (float)param);
    }
}

