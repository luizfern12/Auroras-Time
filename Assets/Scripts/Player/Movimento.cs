using UnityEngine;

public class Movimento : MonoBehaviour {
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform pe;
    [SerializeField] private LayerMask layerChao;

    [Header("Floats")]
    [SerializeField] private float distanciaCheckarPulo;
    [SerializeField] private float velocidade = 8f;
    [SerializeField] private float velocidadeCorrendo = 10f;
    [SerializeField] private float forcaPulo = 12f;

    [Header("Bools")]
    [SerializeField] private bool estaNoChao;


    private float velocidadeMovimento;

    private void Update() {
        estaNoChao = Physics2D.OverlapBox(pe.position, new Vector2(0.5f, 0.5f), distanciaCheckarPulo, layerChao);

        Mover();
        Virar();
        Pulo();
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
        }

        else {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
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
        }
    }
}