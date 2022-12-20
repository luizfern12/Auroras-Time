using UnityEngine;

public class Ataque : MonoBehaviour {
    [SerializeField] private Animator animator;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("Atacar");
        }
    }
}