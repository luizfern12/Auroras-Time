using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Continue : MonoBehaviour {
    [SerializeField] private GameObject telaCarregamento;
    [SerializeField] private GameObject[] objetosParaDesabilitar;

    [SerializeField] private NewGame newGame;

    [SerializeField] private Button botaoContinue; 

    private void Start() {
        if (PlayerPrefs.GetString("FaseAtual") == newGame.cena) {
            botaoContinue.interactable = false;
        }

        else if (PlayerPrefs.GetString("FaseAtual") == null) {
            botaoContinue.interactable = false;
        }

        else if (PlayerPrefs.GetString("FaseAtual") == "") {
            botaoContinue.interactable = false;
        }

        else if (PlayerPrefs.GetString("FaseAtual") == "Menu") {
            botaoContinue.interactable = false;
        }

        else if (PlayerPrefs.GetString("FaseAtual") == "Creditos") {
            botaoContinue.interactable = false;
        }

        else {
            botaoContinue.interactable = true;
        }
    }

    public void CarregarJogo() {
        StartCoroutine(Esperar());
    }

    private IEnumerator Esperar() {
        telaCarregamento.SetActive(true);

        foreach (GameObject objeto in objetosParaDesabilitar) {
            objeto.SetActive(false);
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(CarregarCena());
    }

    private IEnumerator CarregarCena () {
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("FaseAtual"));
        
        while (!operation.isDone) {
            Debug.Log(operation.progress);
                
            yield return null;
        }        
    }
}