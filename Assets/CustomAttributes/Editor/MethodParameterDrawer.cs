using System;
using System.Reflection;

public abstract class MethodParameterDrawer {
    public abstract void InitializeParameter(ref object param, ParameterInfo propertyInfo);
    public abstract void DrawParameter(ref object param, ParameterInfo propertyInfo);
}