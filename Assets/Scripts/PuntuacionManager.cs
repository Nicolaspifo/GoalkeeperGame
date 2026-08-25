using System;
using TMPro;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    [Header("playerData")]
    public PlayerData PlayerData;

    public GameObject CorazonPrefab;
    public GameObject PoderPrefab;

    private TMP_Text TextoPuntuacion;
    private TMP_Text TextoVida;
    private GameObject ContenedorCorazones;
    private TMP_Text TextoPoder;
    private GameObject BarraPoder;

    private int puntuacion;
    private int puntuacionMaxima;
    private int vida;
    private int poder;
    private int PoderNecesario;



    private void Awake()
    {
        // Inicializar referencias a los objetos de la UI
        TextoPuntuacion = GameObject.Find("TextoPuntuacion").GetComponent<TMP_Text>();
        BarraPoder = GameObject.Find("Power");
        ContenedorCorazones = GameObject.Find("Health");

        //inicilizar las variables del juego
        puntuacion = 0;
        puntuacionMaxima = PlayerData.PuntuacionMaxima;
        vida = PlayerData.Vidas;
        poder = 0;
        PoderNecesario = PlayerData.PoderMaximo;
        TextoPuntuacion.text = "" + puntuacion;

        // Crear corazones en la UI según la vida inicial
        CrarCorazones();
    }

    private void CrarCorazones()
    {
        for (int i = 0; i < vida; i++)
        {
            Instantiate(CorazonPrefab, ContenedorCorazones.transform);
        }
    }
    public void ActualizarPuntuacion(string TagObjeto )
    {
        if (TagObjeto == "ObjetoPositivo")
        {
            PuntuacionPositiva();
        }
        else if(TagObjeto == "ObjetoPoder")
        {
            Poder();
        }
        else
        {
            PuntuacionNegativa();
        }
    }

    private void PuntuacionNegativa()
    {
        Transform parent = ContenedorCorazones.transform;
        if (vida > 0)
        {
            vida--;
            if (vida <= 0)
            {
                GameOver();
            }
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                Transform child = parent.GetChild(i);
                Transform corazon = child.Find("Image");

                if (corazon != null && corazon.gameObject.activeSelf)
                {
                    corazon.gameObject.SetActive(false);
                    return;
                }
            }
            
        }
    }

    private void PuntuacionPositiva()
    {
        if (vida > 0)
        {
            puntuacion++;
            TextoPuntuacion.text = "" + puntuacion;
            if (puntuacion == puntuacionMaxima)
            {
                Debug.Log("Pasaste Nivel");
                Time.timeScale = 0;
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    private void Poder()
    {
        if (poder < PoderNecesario)
        {
            poder++;
        }
        if (poder == PoderNecesario)
        {
            TextoPoder.color = Color.yellow;
            GameObject CanvasUI = GameObject.Find("CanvasUI");
            foreach (Transform hijo in CanvasUI.transform)
            {
                if (hijo.name == "BotonPoder")
                {
                    hijo.gameObject.SetActive(true);
                }
            }
        }
    }

    public void ResetearPoder()
    {
        poder = 0;
    }
}
