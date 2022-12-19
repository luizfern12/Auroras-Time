using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [Header("Vida")]
    [Range(0, 7)]
    [SerializeField] private int vida;

    [Range(0, 7)]
    [SerializeField] private int numeroCoracoes;

    [SerializeField] private Image[] coracoes;
    [SerializeField] private Sprite spriteCoracaoCheio;
    [SerializeField] private Sprite spriteCoracaoVazio;

    [Header("Componentes")]
    [SerializeField] private ChangeScene changeScene;
    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private AudioSource audioSourceDano;

    private void Update() {
        if (vida > numeroCoracoes) {
            vida = numeroCoracoes;
        }

        for (int i = 0; i < coracoes.Length; i++) {
            if (i < vida) {
                coracoes[i].sprite = spriteCoracaoCheio;
            }

            else {
                coracoes[i].sprite = spriteCoracaoVazio;
            }

            if (i < numeroCoracoes) {
                coracoes[i].enabled = true;
            }

            else {
                coracoes[i].enabled = false;
            }

            if (vida <= 0) {
                animatorPlayer.SetBool("Morrer", true);
            }
        }
    }

    public void Dano(int dano) {
        if (dano == 0) {
            vida = 0;
        }

        else {
            vida -= dano;
            audioSourceDano.Play();
        }
    }

    private void Morrer() {
        changeScene.MudarCena(SceneManager.GetActiveScene().name);       
    }

    public void GanharVida(int vidaAdd) {
        if (vidaAdd == 0) {
            vida = numeroCoracoes;
        }

        else {
            vida += vidaAdd;
        }

        if (vida >= numeroCoracoes) {
            vida = numeroCoracoes;
        }
    }
}