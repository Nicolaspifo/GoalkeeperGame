using UnityEngine;

public class Levels : MonoBehaviour
{
    [Header("Player Data")]
    public PlayerData playerData;

    private GameObject SpawnManager;
    private GameObject PuntuacionManager;
    private int level = 1;

    private void Start()
    {
        SpawnManager = GameObject.Find("SpawnManager");
        PuntuacionManager = GameObject.Find("GameManager");
    }

    public void SiguienteNivel(GameObject BotonNext)
    {
        level++;
        BotonNext.SetActive(false);
        playerData.ActualizarPorNivel(level);
        SpawnManager.GetComponent<SpawnManager>().actualizarImpulso();
        PuntuacionManager.GetComponent<PuntuacionManager>().actualizarDatosNextLevel();

        Time.timeScale = 1;
    }
}
