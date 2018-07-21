using System.Reflection;
using UnityEditor;

public class IntParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = 0;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.IntField(ObjectNames.NicifyVariableName(propertyInfo.Name), (int)param);
    }
}

