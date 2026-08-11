using TMPro;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    private TMP_Text TextoPuntuacion;
    private TMP_Text TextoVida;
    private TMP_Text TextoPoder;


    private int puntuacion = 0;
    private int vida = 5;
    private int poder = 0;



    private void Awake()
    {
        TextoPuntuacion = GameObject.Find("TextoPuntuacion").GetComponent<TMP_Text>();
        TextoVida = GameObject.Find("TextoVida").GetComponent<TMP_Text>();
        TextoPoder = GameObject.Find("TextoPoder").GetComponent<TMP_Text>();

        TextoPuntuacion.text = "" + puntuacion;
        TextoVida.text = "Vidas: " + vida;
        TextoPoder.text = "Poder: " + poder;
    }
    public void ActualizarPuntuacion(string TagObjeto )
    {
        if(TagObjeto == "ObjetoPositivo")
        {
            PuntuacionPositiva();
        }
        else if(TagObjeto == "ObjetoNegativo")
        {
            PuntuacionNegativa();
        }
    }

    private void PuntuacionNegativa()
    {
        if (vida > 0)
        {
            vida--;
            TextoVida.text = "Vidas: " + vida;
            if (vida <= 0)
            {
                GameOver();
            }
        }
    }

    private void PuntuacionPositiva()
    {
        if (vida > 0)
        {
            puntuacion++;
            TextoPuntuacion.text = "" + puntuacion;
            if (puntuacion == 20)
            {
                Debug.Log("Pasaste Nivel");
                Time.timeScale = 0;
            }
            Poder();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    private void Poder()
    {
        if (puntuacion < 10)
        {
            poder++;
            TextoPoder.text = "Poder: " + poder;
            if (poder == 10) TextoPoder.color = Color.yellow;
        }    
    }
}
