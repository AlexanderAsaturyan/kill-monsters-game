using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Transform mainMenu;
    [SerializeField] private Transform recordsMenu;
    [SerializeField] private Transform creditsMenu;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button recordButton;
    [SerializeField] private Button recordsBackButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button creditsBackButton;
    [SerializeField] private Button quitGame;

    private void Start()
    {
        newGameButton.onClick.AddListener(OpenNewGame);
        recordButton.onClick.AddListener(OpenRecordsMenu);
        recordsBackButton.onClick.AddListener(BackToMenuFromRecords);
        creditsButton.onClick.AddListener(OpenCreditsMenu);
        creditsBackButton.onClick.AddListener(BackToMenuFromCredits);
        quitGame.onClick.AddListener(QuitGame);
    }
    public void OpenNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenRecordsMenu()
    {
        recordsMenu.gameObject.SetActive(true);
        int x = PlayerPrefs.GetInt("Score", 77);
        Debug.LogError(x);
        mainMenu.gameObject.SetActive(false);
    }

    public void OpenCreditsMenu()
    {
        creditsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void BackToMenuFromRecords()
    {
        recordsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void BackToMenuFromCredits()
    {
        creditsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
