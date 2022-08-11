using UnityEngine;

public class Pata : MonoBehaviour {
    [SerializeField] private float posXMin;
    [SerializeField] private float poxXMax;
    [SerializeField] private float tmpMin;
    [SerializeField] private float tmpMax;

    [SerializeField] private float timer;
    [SerializeField] private float tmpAlea;

    public int quantidadeVida;
    
    public int vida;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particulaImpacto;
    [SerializeField] private ChangeScene changeScene;

    public bool subir;
    [SerializeField] private bool noChao;

    private void Start() {
        vida = quantidadeVida;

        tmpAlea = Random.Range(tmpMin, tmpMax);
    }

    private void FixedUpdate() {
        if (vida <= 0) {
            Destroy(this.gameObject);
            changeScene.MudarCena("Creditos");
        }
    }

    private void Update() {
        if (timer != tmpAlea && !noChao) { 
            timer += 1f * Time.deltaTime;
        }

        if (timer >= tmpAlea) {
            if (vida <= quantidadeVida / 2) {
                tmpAlea = Random.Range(tmpMin / 2, tmpMax / 2);
            }

            else if (vida <= quantidadeVida / 4) {
                tmpAlea = Random.Range(tmpMin / 3, tmpMax / 3);
            }

            else {
                tmpAlea = Random.Range(tmpMin, tmpMax);
            }

            noChao = true;

            transform.position = new Vector3(Random.Range(posXMin, poxXMax), transform.position.y, transform.position.z);
            timer = 0f;

            animator.SetBool("descer", true);
            animator.SetBool("subir", false);
        }
    }

    public void SetNNoChao() {
        subir = false;
        noChao = false;
    }

    public void SetSubir() {
        if (particulaImpacto != null) {
            particulaImpacto.Play();
        }

        subir = true;

        animator.SetBool("subir", true);
        animator.SetBool("descer", false);
    }
}