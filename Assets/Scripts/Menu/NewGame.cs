using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGame : MonoBehaviour {
    [SerializeField] private GameObject telaCarregamento;
    [SerializeField] private GameObject[] objetosParaDesabilitar;
    [SerializeField] private string[] variaveisIntParaResetar;
    [SerializeField] private string[] variaveisStringParaResetar;

    public string cena;

    [SerializeField] private bool debug = false;

    public void CarregarJogo() {
        StartCoroutine(Esperar());
    }

    private IEnumerator Esperar() {
        telaCarregamento.SetActive(true);

        foreach (GameObject objeto in objetosParaDesabilitar) {
            objeto.SetActive(false);
        }

        if (debug) {
            foreach (string variavel in variaveisStringParaResetar) {
                PlayerPrefs.SetString(variavel, null);
            }

            foreach (string variavel in variaveisIntParaResetar) {
                PlayerPrefs.SetInt(variavel, 0);      
            } 

            PlayerPrefs.SetString("DashDesbloqueado", "true");     
            PlayerPrefs.SetInt("NumeroPulos", 2);
        } 

        else {
            foreach (string variavel in variaveisStringParaResetar) {
                PlayerPrefs.SetString(variavel, null);
            }

            foreach (string variavel in variaveisIntParaResetar) {
                PlayerPrefs.SetInt(variavel, 0);      
            } 
        }

        PlayerPrefs.SetString("FaseAtual", cena);

        yield return new WaitForSeconds(3);
        StartCoroutine(CarregarCena(cena));
    }

    private IEnumerator CarregarCena (string cena) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(cena);
        
        while (!operation.isDone) {
            yield return null;
        }        
    }
}