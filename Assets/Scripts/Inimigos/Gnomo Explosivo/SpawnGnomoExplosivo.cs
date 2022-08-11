using UnityEngine;

public class SpawnGnomoExplosivo : MonoBehaviour {
    [SerializeField] private GameObject prefabGnomo;
    [SerializeField] private Transform[] spawnpointsGnomos;
    [SerializeField] private Pata pata;

    [SerializeField] private float tmpSpawnMaximo;
    [SerializeField] private float tmpSpawnMinimo;

    private float tmpAlea;

    private float timer;

    private void Start() {
        tmpAlea = Random.Range(tmpSpawnMinimo, tmpSpawnMaximo);
    }

    private void FixedUpdate() {
        timer += Time.deltaTime;

        if (timer >= tmpAlea) {
            int pontoSpawnEscolhido = Random.Range(0, spawnpointsGnomos.Length);
            
            timer = 0f;

            if (pata.vida <= pata.quantidadeVida / 2) {
                tmpAlea = Random.Range(tmpSpawnMinimo / 2, tmpSpawnMaximo / 2);
            }

            else if (pata.vida <= pata.quantidadeVida / 4) {
                tmpAlea = Random.Range(tmpSpawnMinimo / 4, tmpSpawnMaximo / 4);
            }

            else {
                tmpAlea = Random.Range(tmpSpawnMinimo, tmpSpawnMaximo);
            }

            Instantiate(prefabGnomo, spawnpointsGnomos[pontoSpawnEscolhido].position, spawnpointsGnomos[pontoSpawnEscolhido].rotation);
        }
    }
}