using UnityEngine;

public class MudarMenu : MonoBehaviour {
    [SerializeField] private GameObject objetoDesativar;
    [SerializeField] private GameObject objetoAtivar;

    public void Mudar() {
        objetoAtivar.SetActive(true);
        objetoDesativar.SetActive(false);
    }
}