using UnityEngine;

public class GnomoMudaDirecao : MonoBehaviour {
    [SerializeField] private Gnomo scriptGnomo;
    [SerializeField] private int direcaoMudar = 2;

    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Chao") {
            scriptGnomo.direcao = direcaoMudar;
        }
    }
}