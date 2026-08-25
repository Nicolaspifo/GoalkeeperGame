using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashController : MonoBehaviour
{
    [Header("Escena siguiente")]
    public string nextScene = "MenuPrincipal";

    [Header("Referencias")]
    public GameObject logoObject;      // el objeto Image_logo con su animación
    public Slider loadingBar;          // la barra de carga

    [Header("Tiempos")]
    public float logoAnimDuration = 1f; // duración de tu animación del logo (fade+bounce)
    public float minDisplayTime = 1.5f; // tiempo mínimo visible de la barra
    public float smoothSpeed = 2f;      // qué tan rápido se suaviza el avance de la barra

    void Start()
    {
        // Ocultamos la barra al inicio, solo se ve el logo animándose
        if (loadingBar != null)
            loadingBar.gameObject.SetActive(false);

        StartCoroutine(PlaySplashSequence());
    }

    IEnumerator PlaySplashSequence()
    {
        // 1. Esperamos a que termine la animación del logo
        yield return new WaitForSeconds(logoAnimDuration);

        // 2. Ahora sí mostramos la barra y empezamos a cargar
        if (loadingBar != null)
            loadingBar.gameObject.SetActive(true);

        yield return StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        float elapsed = 0f;
        float displayedProgress = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            elapsed += Time.deltaTime;

            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);
            // Suavizamos el valor mostrado en vez de saltar directo al real
            displayedProgress = Mathf.Lerp(displayedProgress, targetProgress, Time.deltaTime * smoothSpeed);

            if (loadingBar != null)
                loadingBar.value = displayedProgress;

            bool readyToFinish = operation.progress >= 0.9f && elapsed >= minDisplayTime;
            bool barVisuallyFull = displayedProgress >= 0.98f;

            if (readyToFinish && barVisuallyFull)
            {
                if (loadingBar != null)
                    loadingBar.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}