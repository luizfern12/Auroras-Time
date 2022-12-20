using UnityEngine;

public class VisaoInimigo : MonoBehaviour {
    [SerializeField] private float distanciaVisao = 5f;
    
    public bool playerNaVisao;
    public float distanciaPlayer;

    private RaycastHit2D visao;    

    private void FixedUpdate() {
        visao = Physics2D.Raycast(transform.position, transform.right, distanciaVisao);

        if (visao.collider != null) {
            if (visao.collider.gameObject.CompareTag("Player")) {
                Debug.DrawRay(transform.position, transform.right * visao.distance, Color.green);
                
                distanciaPlayer = visao.distance;
                playerNaVisao = true;
            }

            else {
                Debug.DrawRay(transform.position, transform.right * visao.distance, Color.white);
                playerNaVisao = false;
            }
        }

        else {
            Debug.DrawRay(transform.position, transform.right * distanciaVisao, Color.red);
            playerNaVisao = false;
        }
    }
}