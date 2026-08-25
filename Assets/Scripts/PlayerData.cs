using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Id del personaje")]
    // Guarda el índice o id del personaje elegido
    public int selectedCharacterId;

    [Header("Dificultad del juego")]
    public int Vidas;
    public int PuntuacionMaxima;
    public int PoderMaximo;

    [Header("Rangos dinamicos por nivel")]

    public int[] velocidad;


}
