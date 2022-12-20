using UnityEngine;

public class DanoNoInimigo : MonoBehaviour {
    [SerializeField] private int dano;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Inimigo")) {
            other.gameObject.GetComponent<VidaInimigo>().Dano(dano);
        }
    }
}