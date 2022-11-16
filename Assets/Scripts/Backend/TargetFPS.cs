using UnityEngine;

public class TargetFPS : MonoBehaviour {
    private void Start() {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}