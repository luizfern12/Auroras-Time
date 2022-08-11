using UnityEngine;

public class CabecaGnomo : MonoBehaviour {
    [SerializeField] private Gnomo scriptGnomo;

    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Pe") {
            if (colisao.gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < -0.1) {
                scriptGnomo.TomarDano();
            }
        }
    }
}