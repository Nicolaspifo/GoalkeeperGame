using Unity.VisualScripting;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{
    private GameObject ObjetoActual;


    private void Start()
    {
        ObjetoActual = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Limite":
                {
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Player":
                {
                    DestruirObjeto(ObjetoActual);
                    break;
                }
            case "Porteria":
                {
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

}
