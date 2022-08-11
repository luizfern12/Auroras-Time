using UnityEngine;

public class DisableAnimator : MonoBehaviour {
    public void Disable() {
        GetComponent<Animator>().enabled = false;
    }
}