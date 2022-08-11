using UnityEngine;

public class PoderFlor : MonoBehaviour {
    [SerializeField] private float tempo = 1f;
    [SerializeField] private float velocidade = 1f;

    Rigidbody2D rb;

    private void Start() {
        Destroy(gameObject, tempo);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (transform.rotation.y == 0) {
            rb.velocity = new Vector2(velocidade, 0);
        }

        else { 
            rb.velocity = new Vector2(-velocidade, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6) {
            if (other.gameObject.GetComponent<Gnomo>().vida == 1) {
                other.gameObject.GetComponent<Gnomo>().vida = 2;
                Destroy(gameObject);
            }
        }

        else if (other.gameObject.tag == "Pata") {
            other.gameObject.GetComponentInParent<Pata>().vida -= 1;
            Destroy(gameObject); 
        }
        
        else {
            Destroy(gameObject);
        }
    }
}