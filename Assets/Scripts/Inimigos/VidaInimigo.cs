using UnityEngine;

public class VidaInimigo : MonoBehaviour {
    [SerializeField] private int vida;
    [SerializeField] private Animator animator;

    private void FixedUpdate() {
        if (vida <= 0) {
            animator.SetBool("Morto", true);
        }
    }

    public void Dano(int dano) {
        vida -= dano;
        animator.SetTrigger("Dano");
    }

    public void Morrer() {
        Destroy(gameObject);
    }
}