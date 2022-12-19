using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    [SerializeField] private GameObject telaCarregamento;
    [SerializeField] private GameObject[] objetosParaDesabilitar;

    [SerializeField] private float tempoLoadingFake;

    public void MudarCena(string cena) {
        StartCoroutine(Esperar(cena));
    }

    private IEnumerator Esperar(string cena) {
        telaCarregamento.SetActive(true);

        foreach (GameObject objeto in objetosParaDesabilitar) {
            Destroy(objeto);
        }
        
        yield return new WaitForSeconds(tempoLoadingFake);

        StartCoroutine(CarregarCena(cena));
    }

    private IEnumerator CarregarCena (string cena) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(cena);

        while (!operation.isDone) {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}