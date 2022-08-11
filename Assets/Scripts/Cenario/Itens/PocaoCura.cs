using UnityEngine;

public class PocaoCura : MonoBehaviour {
    [SerializeField] private GameController gameController;
    [SerializeField] private Transform transformPai;
    [SerializeField] private Rigidbody2D rbPai;

    [SerializeField] private float posY;
    [SerializeField] private float posXMin;
    [SerializeField] private float posXMax;

    [SerializeField] private float tmpMax = 8f;
    [SerializeField] private float tmpMin = 4f;

    [SerializeField] private float tmpAlea;
    [SerializeField] private float posAlea;

    private float timer;
    private bool morrendo;

    private void Start() {
        tmpAlea = Random.Range(tmpMin, tmpMax);
        posAlea = Random.Range(posXMin, posXMax);
    }

    private void Update() {
        if (gameController.vida == 1 && !morrendo) {
            morrendo = true;

            tmpAlea = Random.Range(tmpMin, tmpMax);
            posAlea = Random.Range(posXMin, posXMax);
            transformPai.position = new Vector2(posAlea, posY);
        }

        if (gameController.vida >= 2) {
            morrendo = false;
        }

        if (morrendo) {
            timer += 1f * Time.deltaTime;

            if (timer >= tmpAlea) {
                timer = tmpAlea;
                rbPai.gravityScale = 1f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D colisor) {
        if (colisor.gameObject.tag == "Player") {
            gameController.vida = 3;
            morrendo = false;
            timer = 0;
            
            transformPai.position = new Vector3(0, posY, 0);
            rbPai.gravityScale = 0f;
        }
    }
}