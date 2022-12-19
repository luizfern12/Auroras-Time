using UnityEngine;

public class RecuperaVida : MonoBehaviour {
    [SerializeField] private GameController gmController;
    [SerializeField] private AudioSource audioSourceColetar;

    [Header("Quantidade vida (0 para completar)")]
    [SerializeField] private int vida;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gmController.GanharVida(vida);
            audioSourceColetar.Play();
            Destroy(gameObject);
        }
    }
}