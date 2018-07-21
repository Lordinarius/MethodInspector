using System.Reflection;
using UnityEditor;

public class DoubleParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = 0d;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.DoubleField(ObjectNames.NicifyVariableName(propertyInfo.Name), (double)param);
    }
}

