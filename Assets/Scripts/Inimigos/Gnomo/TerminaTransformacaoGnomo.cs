using UnityEngine;

public class TerminaTransformacaoGnomo : MonoBehaviour {
    [SerializeField] private Gnomo gnomo;

    public void TerminoTranformacao() {
        gnomo.transformando = false;
    }

    public void Destruir() {
        Destroy(gnomo.gameObject);
    }
}