using UnityEngine;

public class Movimento : MonoBehaviour {
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform transformPe;
    [SerializeField] private LayerMask layerChao;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource audioSourcePulo;

    [Header("Floats")]
    [SerializeField] private float distanciaCheckarPulo;
    [SerializeField] private float velocidade = 8f;
    [SerializeField] private float velocidadeCorrendo = 10f;
    [SerializeField] private float forcaPulo = 12f;

    [Header("Bools")]
    [SerializeField] private bool estaNoChao;
    [SerializeField] private bool funcionando;

    private float velocidadeMovimento;

    private void Update() {
        if (funcionando) {
            estaNoChao = Physics2D.OverlapBox(transformPe.position, new Vector2(1f, 0.5f), distanciaCheckarPulo, layerChao);

            Mover();
            Virar();
            Pulo();
        }

        else {
            rigidBody.velocity = new Vector3(0f, 0f);
            Destroy(this);
        }
    }

    private void Mover() {
        if (Input.GetButton("Correr")) {
            velocidadeMovimento = velocidadeCorrendo;
        }

        else {
            velocidadeMovimento = velocidade;
        }

        if (Input.GetAxisRaw("Horizontal") != 0) {
            rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidadeMovimento, rigidBody.velocity.y);
            animator.SetFloat("Velocidade", velocidadeMovimento);
        }

        else {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
            animator.SetFloat("Velocidade", 0f);
        }
    }

    private void Virar() {
        if (Input.GetAxisRaw("Horizontal") > 0) {
            spriteRenderer.flipX = false;
        }

        else if (Input.GetAxisRaw("Horizontal") < 0) {
            spriteRenderer.flipX = true;
        }
    }

    private void Pulo() {
        if (Input.GetButtonDown("Pulo") && estaNoChao) {
            rigidBody.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);

            audioSourcePulo.Play();
        }

        animator.SetFloat("Velocidade Y", rigidBody.velocity.y);
        animator.SetBool("NoChao", estaNoChao);
    }
}