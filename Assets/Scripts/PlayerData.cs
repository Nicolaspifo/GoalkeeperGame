using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Id del personaje")]
    // Guarda el índice o id del personaje elegido
    public int selectedCharacterId;

    [Header("Vidas")]
    public int VidasBase;
    public float VidasIncremento;
    public int VidasMaximas;

    [Header("Puntuación")]
    public int PuntuacionBase;
    public float PuntuacionIncremento;
    public int PuntuacionMaxima;

    [Header("Poder")]
    public int PoderBase;
    public float PoderIncremento;
    public int PoderMaximoTope;

    [Header("Impulso")]
    public float ImpulsoMinBase;
    public float ImpulsoMaxBase;
    public float ImpulsoIncremento;
    public float ImpulsoTope;

    // Valores actuales (los que se usan en el juego)
    [HideInInspector] public int Vidas;
    [HideInInspector] public int PuntuacionActual;
    [HideInInspector] public int PoderMaximo;
    [HideInInspector] public float[] Impulso;

    private void OnEnable()
    {
        Vidas = VidasBase;
        PuntuacionActual = PuntuacionBase;
        PoderMaximo = PoderBase;

        if (Impulso == null || Impulso.Length < 2)
        {
            Impulso = new float[] { ImpulsoMinBase, ImpulsoMaxBase };
        }  
    }

    public void ActualizarPorNivel(int level)
    {
        float factor = Mathf.Sqrt(level);

        Vidas = Mathf.Min(VidasBase + Mathf.FloorToInt(VidasIncremento * factor), VidasMaximas);
        PuntuacionActual = Mathf.Min(PuntuacionBase + Mathf.FloorToInt(PuntuacionIncremento * factor), PuntuacionMaxima);
        PoderMaximo = Mathf.Min(PoderBase + Mathf.FloorToInt(PoderIncremento * factor), PoderMaximoTope);

        float impulsoMin = Mathf.Min(ImpulsoMinBase + (ImpulsoIncremento * factor), ImpulsoTope);
        float impulsoMax = Mathf.Min(ImpulsoMaxBase + (ImpulsoIncremento * factor), ImpulsoTope);
        Impulso = new float[] { impulsoMin, impulsoMax };
    }
}
