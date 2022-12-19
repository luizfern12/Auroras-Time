using UnityEngine;

public class DanoAoTocar : MonoBehaviour {
    [SerializeField] private GameController gmController;

    [Header("Quantidade dano (0 para instaKill)")]
    [SerializeField] private int dano;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gmController.Dano(dano);
        }
    }
}