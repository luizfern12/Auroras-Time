using UnityEngine;

public class DesbloqueiaPoder : MonoBehaviour {   
    [SerializeField] private string poderDesbloquear;

    private void OnTriggerEnter2D(Collider2D colisao) {
        if (colisao.gameObject.tag == "Player") {
            colisao.gameObject.GetComponent<Movimento>().gameController.audioSourceBlueprint.Play();
            PlayerPrefs.SetString(poderDesbloquear, "true");
            Destroy(gameObject);
        }
    }
}