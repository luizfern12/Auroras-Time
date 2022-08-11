using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class GameController : MonoBehaviour {
    [Header("Componentes")]

    public AudioSource audioSourceBlueprint;
    
    [SerializeField] private AudioSource somDano; 

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer renderer;

    [SerializeField] private ChangeScene changeScene;

    [SerializeField] private Image imagemVida;
    [SerializeField] private Sprite[] spritesVida;

    [Header("Variaveis")]
    [SerializeField] private GameObject menuPausado;

    [SerializeField] private bool invencivel;
    public bool estaFazendoDash;

    [SerializeField] private float tempoInvencibilidade = 3;

    [SerializeField] private AudioSource[] audios;

    public int vida;

    private float timerInvecibilidade;
    private bool pausado = false;

    private void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1f;
    }

    private void FixedUpdate() {
        if (invencivel) {
            timerInvecibilidade += Time.deltaTime;
        }

        if (timerInvecibilidade >= tempoInvencibilidade && invencivel) {
            timerInvecibilidade = 0f;
            invencivel = false;
            renderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void Update() {
        if (vida > 0) {
            imagemVida.sprite = spritesVida[vida - 1];
        }

        if (Input.GetButtonDown("Pausar")) {
            if (pausado) {
                ControlePause(false);
            }

            else {
                ControlePause(true);
            }
        }

        if (SystemInfo.deviceType == DeviceType.Console && Input.GetJoystickNames().Length == 0) {
            ControlePause(true);
        }
    }

    public void TomarDano(int dano) {
        if (!invencivel && !estaFazendoDash) {
            somDano.Play();
            vida -= dano;
            
            if (vida <= 0) {
                changeScene.MudarCena(SceneManager.GetActiveScene().name);
            }

            else {
                invencivel = true;
                renderer.color = new Color(1f, 1f, 1f, 0.75f);
            }
        }
    }

    public void ControlePause(bool pausar) {
        pausado = pausar;
        menuPausado.SetActive(pausar);

        if (pausar) {
            Time.timeScale = 0f;

            foreach (AudioSource audio in audios) {
                audio.GetComponent<AudioSource>().Pause();
            }
        }

        else {
            foreach (AudioSource audio in audios) {
                audio.GetComponent<AudioSource>().UnPause();
            }

            Time.timeScale = 1f;
        }
    }

    public void RetornarParaOMenuPeloMenuDePause(string cena) {
        ControlePause(false);
        changeScene.MudarCena(cena);
    }
}