using UnityEngine;
using UnityEngine.UI;

public class Movimento : MonoBehaviour {
    [Header("Componentes")]

    [SerializeField] private Joystick joystick;
    [SerializeField] private AudioSource somPulo;
    [SerializeField] private AudioSource somDash;
    [SerializeField] private Transform pe;
    [SerializeField] private ParticleSystem poeiraPulo;
    public GameController gameController;

    private Rigidbody2D rigidbody2D;
    
    [HideInInspector] public Animator animator;

    [Header("Float")]
    [SerializeField] private float velocidade = 8f;
    [SerializeField] private float velocidadeParaDash = 1f;
    [SerializeField] private float forcaPulo = 5f;
    [SerializeField] private float forcaDash = 5f;
    [SerializeField] private float tempoEntreDash = 2.5f;
    [SerializeField] private bool dashDesbloqueado = false;
    [SerializeField] private float timerDash;
    [SerializeField] private float distanciaCheckarPulo;

    private float direcaoOlhar = 1f; 
    private float velocidadeDashFramePassado;

    [Header("Bool")]

    [SerializeField] private bool estaNoChao;
    [SerializeField] private bool estaPulando;

    private bool podeFazerDash;
    [HideInInspector] public bool estaFazendoDash = false;

    [Header("Int")]
    [SerializeField] private int numeroPulosMaximo = 2;
    [SerializeField] private int numeroPulosDado;

    [Header("GameObjects")]
    [SerializeField] private Image indicadorDash = null;
    [SerializeField] private GameObject botaoDash;
    [SerializeField] private GameObject inputTouch;

    [SerializeField] private LayerMask layerChao;

    private void Start() { 
        if (transform.localRotation.y != 0) {
            direcaoOlhar = 1f;
        }
        
        else {
            direcaoOlhar = 2f;
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        // Verifica se tem algum valor salvo

        if (PlayerPrefs.GetString("DashDesbloqueado") == "true") {
            dashDesbloqueado = true;
            indicadorDash.enabled = true;
            botaoDash.SetActive(true);
        }

        else {
            dashDesbloqueado = false;
            indicadorDash.enabled = false;
            botaoDash.SetActive(false);
        }

        estaNoChao = Physics2D.OverlapBox(pe.position, new Vector2(0.75f, 0.75f), distanciaCheckarPulo, layerChao);

        animator.SetFloat("VelocidadeY", rigidbody2D.velocity.y);

        if (rigidbody2D.velocity.y < 0f) {
            if (estaNoChao) {
                numeroPulosDado = 0;
                estaPulando = false; 
                estaFazendoDash = false;
                
                animator.SetBool("Pulando", false);
            }

            animator.SetBool("Caindo", true);
        }

        else if (rigidbody2D.velocity.y == 0) {
            if (estaNoChao) {
                numeroPulosDado = 0;
                estaPulando = false; 

                animator.SetBool("Pulando", false);
            }

            animator.SetBool("Caindo", false);
        }

        else if (rigidbody2D.velocity.y > 0) {
            animator.SetBool("Caindo", false);
        }

        Virar();
        Andar();
    }   

    private void Update() {        
        if (dashDesbloqueado && !estaFazendoDash) {
            timerDash += 1f * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump")) {
            Pular();
        }

        if (Input.GetButtonDown("Dash")) {
            Dash();
        }

        gameController.estaFazendoDash = estaFazendoDash;

        MudarFonteInput();
        VerificacoesDash();
    }

    private void Andar() {
        if (Input.GetAxisRaw("Horizontal") != 0f && !estaFazendoDash) {
            rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, rigidbody2D.velocity.y);
            animator.SetBool("Andando", true);
        }

        else if (joystick.Horizontal != 0f && !estaFazendoDash) {
            rigidbody2D.velocity = new Vector2(joystick.Horizontal * velocidade, rigidbody2D.velocity.y);
            animator.SetBool("Andando", true);
        }
        
        else {
            animator.SetBool("Andando", false);

            if (!estaFazendoDash) {
                rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
            }
        }
    }

    private void Virar() {
        if (Input.GetAxisRaw("Horizontal") < 0f && !estaFazendoDash) {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            direcaoOlhar = 1f;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0f && !estaFazendoDash) {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            direcaoOlhar = 2f;
        }

        else if (joystick.Horizontal < 0f && !estaFazendoDash) {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            direcaoOlhar = 1f;
        }

        else if (joystick.Horizontal > 0f && !estaFazendoDash) {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            direcaoOlhar = 2f;
        }
    }

    public void Pular() {
        if (estaNoChao && numeroPulosDado < numeroPulosMaximo) {
            numeroPulosDado += 1;

            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            
            somPulo.Play();
            poeiraPulo.Play();

            estaPulando = true;

            animator.SetBool("Pulando", true);
        }

        else if (estaPulando && numeroPulosDado < numeroPulosMaximo) {
            numeroPulosDado += 1;
            
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);

            somPulo.Play();
        }
    }

    private void VerificacoesDash() {
        if (timerDash >= tempoEntreDash) {
            podeFazerDash = true;
            timerDash = tempoEntreDash;
            indicadorDash.color = new Color(indicadorDash.color.r, indicadorDash.color.g, indicadorDash.color.b, 1f);
        }

        if (estaFazendoDash) {
            if (rigidbody2D.velocity.x <= velocidadeParaDash && rigidbody2D.velocity.x > 0f || rigidbody2D.velocity.x >= -velocidadeParaDash && rigidbody2D.velocity.x < 0f) {
                estaFazendoDash = false;
                rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
            }

            else if (velocidadeDashFramePassado > 0 || velocidadeDashFramePassado < 0) {
                if (rigidbody2D.velocity.x == 0) {
                    estaFazendoDash = false;
                    rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
                }
            }

            velocidadeDashFramePassado = rigidbody2D.velocity.x;
        }
    }

    public void Dash() {
        if (podeFazerDash) {
            somDash.Play();
            if (direcaoOlhar == 1f) {
                rigidbody2D.velocity = Vector2.right * -forcaDash;
                estaFazendoDash = true;
                podeFazerDash = false;
                timerDash = 0f;
            }

            else if (direcaoOlhar == 2f) {
                rigidbody2D.velocity = Vector2.right * forcaDash;
                estaFazendoDash = true;
                podeFazerDash = false;
                timerDash = 0f;
            }

            indicadorDash.color = new Color(indicadorDash.color.r, indicadorDash.color.g, indicadorDash.color.b, 0.5f);
        }

    }

    private void MudarFonteInput() {
        if (Input.touchCount > 0) {
            inputTouch.SetActive(true);
        }

        else if (Input.GetAxisRaw("Horizontal") != 0) {
            inputTouch.SetActive(false);
        }

        else if (Input.GetButtonDown("Jump")) {
            inputTouch.SetActive(false);
        }

        else if (Input.GetButtonDown("Dash")) {
            inputTouch.SetActive(false);
        }


    }
}