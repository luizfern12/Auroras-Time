using UnityEngine;

public class MataPlayer : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Player") {
            colisao.gameObject.GetComponent<Movimento>().gameController.TomarDano(100000);
        }
    }
}