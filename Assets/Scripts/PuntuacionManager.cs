using TMPro;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    public TMP_Text TextoPuntuacion;
    private int puntuacion = 0;

    public void ActualizarPuntuacion(string TagObjeto )
    {
        if(TagObjeto == "ObjetoPositivo")
        {
            puntuacion++;
            TextoPuntuacion.text = "" + puntuacion;
        }
        else if(TagObjeto == "ObjetoNegativo")
        {
            puntuacion--;
            TextoPuntuacion.text = "" + puntuacion;
        }
    }
}
