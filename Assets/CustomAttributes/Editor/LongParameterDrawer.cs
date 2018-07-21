using System.Reflection;
using UnityEditor;

public class LongParameterDrawer : MethodParameterDrawer {
    public override void InitializeParameter(ref object param, ParameterInfo propertyInfo) {
        param = 0L;
    }

    public override void DrawParameter(ref object param,ParameterInfo propertyInfo) {
        param = EditorGUILayout.LongField(ObjectNames.NicifyVariableName(propertyInfo.Name), (long)param);
    }
}

