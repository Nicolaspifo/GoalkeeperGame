using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerManager : MonoBehaviour
{
    GameObject puntuacionManager;

    public void Start()
    {
        puntuacionManager = GameObject.Find("GameManager");
    }
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
                puntuacionManager.GetComponent<PuntuacionManager>().ResetearPoder();

                StartCoroutine(DeactivatePower());

                break;
            }
        }
    }

    public IEnumerator DeactivatePower()
    { 
        yield return new WaitForSeconds(7f);
        GameObject playerManager = GameObject.Find("PlayerManager");
        foreach (Transform hijo in playerManager.transform)
        {
            if (hijo.CompareTag("Player"))
            {
                hijo.localScale = new Vector3(1f, 1f, 1f);
                break;
            }
        }
    }
}
