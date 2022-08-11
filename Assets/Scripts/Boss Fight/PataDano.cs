using UnityEngine;

public class PataDano : MonoBehaviour {
    [SerializeField] private Pata scriptPata;

    private void OnTriggerEnter2D(Collider2D colisor) {
        if (!scriptPata.subir && colisor.gameObject.tag == "Cabeca") {
            if (colisor.gameObject.GetComponentInParent<GameController>()) {
                colisor.gameObject.GetComponentInParent<GameController>().TomarDano(1);
            }

            else if (colisor.gameObject.GetComponentInParent<Gnomo>()) {
                colisor.gameObject.GetComponentInParent<Gnomo>().TomarDano();
            }
        }
    }
}