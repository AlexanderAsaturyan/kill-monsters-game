using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button recordButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitGame;
    [SerializeField] private AudioSource menuMusic;

    private void Start()
    {
        menuMusic.Play();
        newGameButton.onClick.AddListener(OpenNewGame);
        quitGame.onClick.AddListener(QuitGame);
    }
    public void OpenNewGame()
    {
        Debug.Log("OpenNewGame");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
