using UnityEngine;

public class TestScript : MonoBehaviour {
    
    //Button without any parameter
    [InspectButton("My Function")]
    public void TestMethod() {
        Debug.Log("Button pressed");
    }
    
    //Buttons with supported primative parameters
    [InspectButton]
    public void TestMethod(float floatValue,StackTraceLogType enumValue,Vector2 vector2Value) {
        Debug.Log(floatValue);
        Debug.Log(enumValue);
        Debug.Log(vector2Value);
    }
    
    //Button visible in play mode only
    [InspectButton(visibilityMode = InspectButtonAttribute.VisibilityMode.PlayModeOnly)]
    public void TestMethodPlayModeOnly() {
        Debug.Log("Play mode button pressed");
    }
    
    //Button visible in edit mode only
    [InspectButton(visibilityMode = InspectButtonAttribute.VisibilityMode.EditModeOnly)]
    public void TestMethodEditModeOnly() {
        Debug.Log("Edit mode button pressed");
    }
    
}
