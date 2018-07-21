using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class InspectButtonAttribute : Attribute {

    public const string DefaultButtonNameKey = "NONE";
    public MethodInfo methodInfo;
    public object[] properties;
    public VisibilityMode visibilityMode = VisibilityMode.All;

    public string buttonName;

    public InspectButtonAttribute() {
        buttonName = DefaultButtonNameKey;
    }

    public InspectButtonAttribute(string buttonName) {
        this.buttonName = buttonName;
    }
    
    public enum VisibilityMode {
        All,
        EditModeOnly,
        PlayModeOnly
    }
    
}


