using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour {
    [SerializeField] private GameObject telaCarregamento;
    [SerializeField] private GameObject[] objetosParaDesabilitar;

    [SerializeField] private string variavelNecessariaParaMudarCena;
    [SerializeField] private string valorNecessarioVariavelParaMudarCena;

    [SerializeField] private string cenaPaIr;

    [SerializeField] private bool ativado = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !ativado) {
            if (PlayerPrefs.GetString(variavelNecessariaParaMudarCena) == valorNecessarioVariavelParaMudarCena) {
                ativado = true;
                telaCarregamento.SetActive(true);
                PlayerPrefs.SetString("FaseAtual", cenaPaIr);

                foreach (GameObject objeto in objetosParaDesabilitar) {
                    Destroy(objeto);
                }

                StartCoroutine(Esperar()); 
            }
        }
    }

    private IEnumerator Esperar() {
        yield return new WaitForSeconds(3);
        StartCoroutine(CarregarCena());
    }
    
    private IEnumerator CarregarCena () {
        AsyncOperation operation = SceneManager.LoadSceneAsync(cenaPaIr);

        while (!operation.isDone) {
            yield return null;
        }
    }
}