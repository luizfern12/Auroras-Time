using UnityEngine;

public class MudaSpritePorPlataforma : MonoBehaviour {
    [System.Serializable]
    private struct objeto {
        public SpriteRenderer spriteRenderer;
        public Sprite sprMobile;
        public Sprite sprDesktop;
        public Sprite sprDesconhecido;
        public Sprite sprConsole;
    }

    [SerializeField] private objeto[] structObjetos;

    private void Start() {
        if (SystemInfo.deviceType == DeviceType.Desktop) {
            foreach (objeto structObj in structObjetos) {
                structObj.spriteRenderer.sprite = structObj.sprDesktop;
            }
        }

        else if (SystemInfo.deviceType == DeviceType.Handheld) {
            foreach (objeto structObj in structObjetos) {
                structObj.spriteRenderer.sprite = structObj.sprMobile;
            }
        }

        else if (SystemInfo.deviceType == DeviceType.Console) {
            foreach (objeto structObj in structObjetos) {
                structObj.spriteRenderer.sprite = structObj.sprConsole;
            }
        }

        else {
            foreach (objeto structObj in structObjetos) {
                structObj.spriteRenderer.sprite = structObj.sprDesconhecido;
            }
        }
    }
}