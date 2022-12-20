using UnityEngine;

public class Carno : MonoBehaviour {
    [Header("Componentes")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource somRosnado;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameController gmController;

    [Header("Visão")]
    [SerializeField] private VisaoInimigo[] scriptsVisao;

    [SerializeField] private float distanciaPlayer;
    [SerializeField] private float distanciaFatalPlayer;

    [SerializeField] private bool playerNaVisao = false;
    [SerializeField] private bool playerEmDistanciaFatal;

    [Header("Velocidades")]
    [SerializeField] private float velocidadeAndar = 6f;

    [Header("Tempo")]
    [SerializeField] private float tempoEntreAtaques;

    [Header("Dano")]
    [SerializeField] private int dano = 1;

    [Header("Debug")]
    [SerializeField] private bool podeAtacar = true;
    [SerializeField] private float timerAtacar = 0f;

    [SerializeField] private int virado = -1; 

    private void Update() {
        Ver();

        if (!podeAtacar) {
            timerAtacar += 1f * Time.deltaTime;

            if (timerAtacar >= tempoEntreAtaques) {
                timerAtacar = 0f;
                podeAtacar = true;
            }
        }

        if (playerNaVisao) {
            if (playerEmDistanciaFatal) {
                Parar();
                Atacar();
            }

            else {
                Andar();
            }
        }

        else {
            Parar();
        }
    }

    private void Ver() {
        for (int i = 0; i < scriptsVisao.Length; i++) {
            if (scriptsVisao[i].playerNaVisao) {
                playerNaVisao = true;
                break;
            }

            else {
                if (i == scriptsVisao.Length - 1) {
                    playerNaVisao = false;
                }
            }
        }

        if (playerNaVisao) {
            distanciaPlayer = 100000f;

            foreach (VisaoInimigo script in scriptsVisao) {
                if (script.playerNaVisao) {
                    if (script.distanciaPlayer < distanciaPlayer) {
                        Debug.Log(script.distanciaPlayer);
                        distanciaPlayer = script.distanciaPlayer;
                    }
                }
            }
        }

        if (distanciaPlayer <= distanciaFatalPlayer) {
            playerEmDistanciaFatal = true;
        }

        else {
            playerEmDistanciaFatal = false;
        }
    }

    private void Andar() {
        rb.velocity = new Vector2(velocidadeAndar * virado, rb.velocity.y);
        animator.SetFloat("Velocidade", velocidadeAndar);
    }

    private void Parar() {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        animator.SetFloat("Velocidade", 0f);
    }
    
    private void Atacar() {
        if (podeAtacar) {
            animator.SetTrigger("Atacar");
            gmController.Dano(dano);
            podeAtacar = false;
        }
    }

    private void Rosnar() {
        somRosnado.Play();
    }
}