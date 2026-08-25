using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        //Limita el juego a 60 FPS
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

    }
}
