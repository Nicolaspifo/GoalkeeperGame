using UnityEngine;
using UnityEngine.EventSystems;

public class PowerManager : MonoBehaviour
{

    public void ActivatePower()
    {
        GameObject botonClickeado = EventSystem.current.currentSelectedGameObject;
        botonClickeado.SetActive(false);
        Debug.Log("Poder activado con el boton" + botonClickeado.name);

        GameObject playerManager = GameObject.Find("PlayerManager");
        foreach (Transform hijo in playerManager.transform)
        {
            if (hijo.CompareTag("Player"))
            {
                hijo.localScale = new Vector3(2f, 2f, 2f);
                break;
            }
        }
    }
}
