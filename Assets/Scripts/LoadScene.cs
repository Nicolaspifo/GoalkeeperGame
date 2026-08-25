using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public void Play()
    {
        AudioManager.Instance.PlayButtonClick();
        SceneManager.LoadScene(sceneName);
    }
}