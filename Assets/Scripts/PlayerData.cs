using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    // Guarda el índice o id del personaje elegido
    public int selectedCharacterId;
}
