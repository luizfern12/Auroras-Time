using UnityEngine;

public class DesabilitaPorPlataforma : MonoBehaviour {
    [System.Serializable]
    private struct objeto {
        public GameObject gameObject;
        public bool desabilitaMobile;
        public bool desabilitaDesktop;
        public bool desabilitaDesconhecido;
        public bool desabilitaConsole;
    }

    [SerializeField] private objeto[] structObjetos;

    private void Start() {
        if (SystemInfo.deviceType == DeviceType.Desktop) {
            foreach (objeto structObj in structObjetos) {
                if (structObj.desabilitaDesktop) {
                    structObj.gameObject.SetActive(false);
                }
            }
        }

        else if (SystemInfo.deviceType == DeviceType.Handheld) {
            foreach (objeto structObj in structObjetos) {
                if (structObj.desabilitaMobile) {
                    structObj.gameObject.SetActive(false);
                }
            }
        }

        else if (SystemInfo.deviceType == DeviceType.Console) {
            foreach (objeto structObj in structObjetos) {
                if (structObj.desabilitaConsole) {
                    structObj.gameObject.SetActive(false);
                }
            }
        }

        else {
            foreach (objeto structObj in structObjetos) {
                if (structObj.desabilitaDesconhecido) {
                    structObj.gameObject.SetActive(false);
                }
            }
        }
    }
}