using UnityEngine;

public class DanoNoInimigo : MonoBehaviour {
    [SerializeField] private float distanciaAtaque = .2f;
    [SerializeField] private int dano;

    private RaycastHit2D visao;    

    public void Atacar() {
        visao = Physics2D.Raycast(transform.position, transform.right, distanciaAtaque);

        if (visao.collider != null) {
            if (visao.collider.gameObject.CompareTag("Inimigo")) {
                Debug.DrawRay(transform.position, transform.right * visao.distance, Color.green);
                visao.collider.gameObject.GetComponent<VidaInimigo>().Dano(dano);
            }

            else {
                Debug.DrawRay(transform.position, transform.right * visao.distance, Color.white);
            }
        }

        else {
            Debug.DrawRay(transform.position, transform.right * distanciaAtaque, Color.red);
        }
    }
}