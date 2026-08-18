using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public PlayerData PlayerData;
    public GameObject[] characters;

    void Awake()
    {
        GameObject ReferenceSpawn = GameObject.Find("SpawnPlayerObject");
        GameObject PlayerManager = gameObject.GetComponent<GameObject>();

        int selectedCharacterId = PlayerData.selectedCharacterId -1;
        if (selectedCharacterId >= 0 && selectedCharacterId < characters.Length)
        {
            Instantiate(characters[selectedCharacterId], ReferenceSpawn.transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogError("ID de personaje seleccionado no válido: " + selectedCharacterId);
        }
    }
}
