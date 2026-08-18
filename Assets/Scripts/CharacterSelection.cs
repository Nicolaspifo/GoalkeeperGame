using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public PlayerData PlayerData;

    public void SelectCharacter()
    {
        int id = int.Parse(gameObject.name);
        PlayerData.selectedCharacterId = id;
        Debug.Log("Personaje seleccionado con ID: " + id);
    }



}
