using UnityEngine;

public class PlataformaQueQuebra : MonoBehaviour {
    [SerializeField] private float tempoParaQuebrar;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Pe") {
            Destroy(this.gameObject, tempoParaQuebrar);
        }
    }    
}