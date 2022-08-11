using UnityEngine;

public class GnomoExplosivo : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D Colisor) {
        if (Colisor.gameObject.tag == "Pulavel") {
            Debug.Log("Explodi");
            Destroy(this.gameObject);
        }
    }
}