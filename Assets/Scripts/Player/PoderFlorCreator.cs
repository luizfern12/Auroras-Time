using UnityEngine;
using UnityEngine.UI;

public class PoderFlorCreator : MonoBehaviour {
    [SerializeField] private AudioSource som;

    [SerializeField] private GameObject prefabPoderFlor;
    [SerializeField] private GameObject botaoPoderFlor;
    [SerializeField] private Transform transformPlayer;

    [SerializeField] private Animator animator;
    
    [SerializeField] private float delayPoder; 

    [SerializeField] private Image indicadorPoder;

    [SerializeField] private bool poderDesbloqueado = false;

    private float timer;

    private void FixedUpdate() {
        if (poderDesbloqueado) {
            timer += 1f * Time.deltaTime;
        }
    }

    private void Update() {
        if (timer >= delayPoder) {
            timer = delayPoder;
            indicadorPoder.color = new Color(indicadorPoder.color.r, indicadorPoder.color.g, indicadorPoder.color.b, 1f);
        }

        if (Input.GetButtonDown("PoderFlor") && SystemInfo.deviceType != DeviceType.Handheld) {
            CriaFlor();
        }

        if (PlayerPrefs.GetString("PoderFlorDesbloqueado") == "true") {
            botaoPoderFlor.SetActive(true);
            poderDesbloqueado = true;
            indicadorPoder.enabled = true;
        }

        else {
            botaoPoderFlor.SetActive(false);
            poderDesbloqueado = false;
            indicadorPoder.enabled = false;
        }
    }

    public void CriaFlor() {
        if (timer >= delayPoder) {
            animator.SetTrigger("Ataque");
            Instantiate(prefabPoderFlor, transform.position, transformPlayer.localRotation);
            som.Play();
            indicadorPoder.color = new Color(indicadorPoder.color.r, indicadorPoder.color.g, indicadorPoder.color.b, 0.5f);
            timer = 0f;
        }
    }
}