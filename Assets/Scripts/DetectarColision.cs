using Unity.VisualScripting;
using UnityEngine;


public class DetectarColision : MonoBehaviour
{
    private GameObject ObjetoActual;
    private GameObject puntuacionManager;

    private void Start()
    {
        puntuacionManager = GameObject.Find("GameManager");
        ObjetoActual = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Limite" when ObjetoActual.tag == "ObjetoPositivo":
                {
                    AudioManager.Instance.PlayCatchCorrect();
                    ActualizarPuntuacion(ObjetoActual.tag);
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Limite" when ObjetoActual.tag == "ObjetoNegativo" || ObjetoActual.tag == "ObjetoPoder":
                {
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Player" when ObjetoActual.tag == "ObjetoNegativo":
                {
                    AudioManager.Instance.PlayCatchWrong();
                    ActualizarPuntuacion(ObjetoActual.tag);
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Player" when ObjetoActual.tag == "ObjetoPoder":
                {
                    AudioManager.Instance.PlayPowerUp();
                    ActualizarPuntuacion(ObjetoActual.tag);
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Porteria" when ObjetoActual.tag == "ObjetoNegativo" || ObjetoActual.tag == "ObjetoPoder":
                {
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Porteria" when ObjetoActual.tag == "ObjetoPositivo":
                {  
                    AudioManager.Instance.PlayGoalScored();
                    ActualizarPuntuacion("ObjetoNegativo");
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            default:
                {
                    Debug.Log("Objeto no reconocido: " + other.tag);
                    break;
                }
        }
    }



    private void DestruirObjeto(GameObject objeto)
    {
        Destroy(objeto);
    }

    private void ActualizarPuntuacion(string objeto)
    {
        puntuacionManager.GetComponent<PuntuacionManager>().ActualizarPuntuacion(objeto);
    }
}