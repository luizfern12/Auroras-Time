using UnityEngine;

public class BloqueiaPoder : MonoBehaviour {
    [SerializeField] private string poder;

    private void Start() {
        PlayerPrefs.SetString(poder, "false");
    }
}
