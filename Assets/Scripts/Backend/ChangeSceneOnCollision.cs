using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneOnCollision : MonoBehaviour {
    [SerializeField] private GameObject telaCarregamento;
    [SerializeField] private GameObject[] objetosParaDesabilitar;

    [SerializeField] private string cena;

    [SerializeField] private float tempoLoadingFake;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(Esperar());
        }
    }

    private IEnumerator Esperar() {
        telaCarregamento.SetActive(true);

        foreach (GameObject objeto in objetosParaDesabilitar) {
            Destroy(objeto);
        }
        
        yield return new WaitForSeconds(tempoLoadingFake);

        StartCoroutine(CarregarCena());
    }

    private IEnumerator CarregarCena () {
        AsyncOperation operation = SceneManager.LoadSceneAsync(cena);

        while (!operation.isDone) {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}