using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayClick);
        quitButton.onClick.AddListener(() => Application.Quit());

        Time.timeScale = 1.0f;
    }

    private void PlayClick()
    {
        Loader.Load(Loader.Scene.GameScene);
    }
}
