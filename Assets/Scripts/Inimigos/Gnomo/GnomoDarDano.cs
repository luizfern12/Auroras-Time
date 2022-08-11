using UnityEngine;

public class GnomoDarDano : MonoBehaviour {
    [SerializeField] private Gnomo scriptGnomo;

    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Player") {
            if (scriptGnomo.agressivo && !scriptGnomo.transformando) {
                colisao.gameObject.GetComponent<Movimento>().gameController.TomarDano(scriptGnomo.dano);
            }
        }
    }
}