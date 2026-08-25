using Microsoft.Unity.VisualStudio.Editor;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UIImage = UnityEngine.UI.Image;

public class PuntuacionManager : MonoBehaviour
{
    [Header("playerData")]
    public PlayerData PlayerData;

    public GameObject CorazonPrefab;
    private TMP_Text TextoPuntuacion;
    private TMP_Text TextoVida;
    private GameObject ContenedorCorazones;
    private TMP_Text TextoPoder;
    private GameObject BarraPoder;
    private UIImage ImagenBarraPoder;

    private int puntuacion;
    private int puntuacionMaxima;
    private int vida;
    private int poder;
    private int PoderNecesario;



    private void Awake()
    {
        // Inicializar referencias a los objetos de la UI
        TextoPuntuacion = GameObject.Find("TextoPuntuacion").GetComponent<TMP_Text>();
        BarraPoder = GameObject.Find("BarraPoder");
        Transform parent = BarraPoder.transform;
        ImagenBarraPoder = parent.GetChild(0).GetComponent<UIImage>();
        ContenedorCorazones = GameObject.Find("Health");

        //inicilizar las variables del juego
        puntuacion = 0;
        puntuacionMaxima = PlayerData.PuntuacionActual;
        vida = PlayerData.Vidas;
        poder = 0;
        PoderNecesario = PlayerData.PoderMaximo;
        TextoPuntuacion.text = "" + puntuacion;

        // Crear corazones en la UI según la vida inicial
        CrearCorazones();
    }

    public void actualizarDatosNextLevel()
    {
        puntuacion = 0;
        puntuacionMaxima = PlayerData.PuntuacionActual;
        vida = PlayerData.Vidas;
        poder = 0;
        PoderNecesario = PlayerData.PoderMaximo;
        TextoPuntuacion.text = "" + puntuacion;
        CrearCorazones();
    }

    private void Start()
    {
        ResetearPoder();
    }

    private void CrearCorazones()
    {
        // Destruir todos los corazones existentes
        foreach (Transform corazon in ContenedorCorazones.transform)
        {
            Destroy(corazon.gameObject);
        }
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
                GameObject CanvasUI = GameObject.Find("CanvasUI");
                foreach (Transform hijo in CanvasUI.transform)
                {
                    if (hijo.name == "SiguienteNivel")
                    {
                        hijo.gameObject.SetActive(true);
                    }
                }
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
            ImagenBarraPoder.fillAmount = (float)poder / (float)PoderNecesario;
        }
        if (poder == PoderNecesario)
        {
            
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
        ImagenBarraPoder.fillAmount = 0f; ;
    }
}
