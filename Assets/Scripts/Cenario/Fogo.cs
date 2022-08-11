using UnityEngine;

public class Fogo : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Player") {
            colisao.gameObject.GetComponent<GameController>().TomarDano(1);
        }
    }
}