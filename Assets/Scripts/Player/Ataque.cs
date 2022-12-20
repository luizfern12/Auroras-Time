using UnityEngine;

public class Ataque : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private DanoNoInimigo danoScript;
    [SerializeField] private bool atacando;

    private void Update() {
        if (Input.GetMouseButtonDown(0) && !atacando) {
            animator.SetBool("Atacando", true);
            danoScript.Atacar();
            atacando = true;
        }
    }

    public void AcabarAtaque() {
        animator.SetBool("Atacando", false);
        atacando = false;
    }
}