using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [Header("--- Vida ---")]
    [Range(0, 7)]
    [SerializeField] private int vida;

    [Range(0, 7)]
    [SerializeField] private int numeroCoracoes;

    [SerializeField] private Image[] coracoes;
    [SerializeField] private Sprite spriteCoracaoCheio;
    [SerializeField] private Sprite spriteCoracaoVazio;

    private void Start() {

    }

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
        }
    }
}