using UnityEngine;

public class Gnomo : MonoBehaviour {
    [SerializeField] private float velocidadePacifico = 5f;
    [SerializeField] private float velocidadeAgressivo = 6.25f;

    [SerializeField] private GameObject somExplosao;

    [SerializeField] private Animator animatorPacifico;
    [SerializeField] private Animator animatorAgressivo;
    [SerializeField] private SpriteRenderer spriteRendererPacifico;
    [SerializeField] private SpriteRenderer spriteRendererAgressivo;
    [SerializeField] private GameObject somRosnado;

    [SerializeField] private bool caindo;

    private Rigidbody2D rigidBody2D;

    public GameObject spritePacifico;
    public GameObject spriteAgressivo;

    public bool agressivo;
    public bool transformando;

    public int vida = 2;
    public int direcao = 2;
    public int dano = 1;

    private void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (vida == 2 && agressivo) {
            agressivo = false;

            rigidBody2D.velocity = new Vector2(0f, 0f);

            spriteAgressivo.SetActive(false);
            spritePacifico.SetActive(true);

            somRosnado.SetActive(false);

            animatorPacifico.SetTrigger("Transformar");

            transformando = true;
        }

        else if (vida == 1 && !agressivo) {
            agressivo = true;

            rigidBody2D.velocity = new Vector2(0f, 0f);

            spriteAgressivo.SetActive(true);
            spritePacifico.SetActive(false);

            somRosnado.SetActive(true);

            animatorAgressivo.SetTrigger("Transformar");

            transformando = true;
        }

        else if (vida <= 0) {
            transformando = true;
            rigidBody2D.velocity = new Vector2(0f, 0f);
            somExplosao.SetActive(true);
            animatorAgressivo.SetTrigger("Explodir");
        }

        if (rigidBody2D.velocity.y < -0.05 && !transformando) {
            caindo = true;

            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);

            animatorPacifico.SetBool("Caindo", true);
            animatorAgressivo.SetBool("Caindo", true);
        }

        else if (rigidBody2D.velocity.y >= 0 && !transformando) {
            caindo = false;

            animatorPacifico.SetBool("Caindo", false);
            animatorAgressivo.SetBool("Caindo", false);
        }
    }

    private void Update() {
        if (vida > 0 && !transformando && !caindo) {
            if (!agressivo) {
                if (direcao == 2) {
                    rigidBody2D.velocity = new Vector2(velocidadePacifico, rigidBody2D.velocity.y);
                    spriteRendererPacifico.flipX = false;
                    spriteRendererAgressivo.flipX = false;
                    animatorPacifico.SetBool("Andando", true);
                }

                else if (direcao == 1) {
                    rigidBody2D.velocity = new Vector2(-velocidadePacifico, rigidBody2D.velocity.y);
                    spriteRendererPacifico.flipX = true;
                    spriteRendererAgressivo.flipX = true;
                    animatorPacifico.SetBool("Andando", true);
                }

                else {
                    rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                    animatorPacifico.SetBool("Andando", false);
                }
            }

            else {    
                if (direcao == 2) {
                    rigidBody2D.velocity = new Vector2(velocidadeAgressivo, rigidBody2D.velocity.y);
                    spriteRendererPacifico.flipX = false;
                    spriteRendererAgressivo.flipX = false;
                    animatorAgressivo.SetBool("Andando", true);
                }

                else if (direcao == 1) {
                    rigidBody2D.velocity = new Vector2(-velocidadeAgressivo, rigidBody2D.velocity.y);
                    spriteRendererPacifico.flipX = true;
                    spriteRendererAgressivo.flipX = true;
                    animatorAgressivo.SetBool("Andando", true);
                }

                else {
                    rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                    animatorAgressivo.SetBool("Andando", false);
                }
            }
        }
    }

    public void TomarDano() {
        vida -= 1;
    }
}