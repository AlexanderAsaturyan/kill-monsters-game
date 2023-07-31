using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private RectTransform mainMenu;
    [SerializeField] private RectTransform recordsView;
    [SerializeField] private RectTransform creditsView;
    [SerializeField] private Button recordsButton;
    [SerializeField] private Button recordsBackButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button creditsBackButton;
    [SerializeField] private Button quitGame;
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private TextMeshProUGUI recordText;

    private void Start()
    {
        menuMusic.Play();
        newGameButton.onClick.AddListener(OpenNewGame);
        recordsButton.onClick.AddListener(OpenRecordsView);
        creditsButton.onClick.AddListener(OpenCreditsView);
        recordsBackButton.onClick.AddListener(BackToMenuFromRecords);
        creditsBackButton.onClick.AddListener(BackToMenuFromCredits);
        quitGame.onClick.AddListener(QuitGame);
    }

    public void OpenNewGame()
    {
        Debug.Log("OpenNewGame");
        SceneManager.LoadScene(1);
    }

    public void OpenRecordsView()
    {
        mainMenu.gameObject.SetActive(false);
        recordsView.gameObject.SetActive(true);
        ReadRecord();
    }

    public void OpenCreditsView()
    {
        mainMenu.gameObject.SetActive(false);
        creditsView.gameObject.SetActive(true);
    }

    public void BackToMenuFromRecords()
    {
        mainMenu.gameObject.SetActive(true);
        recordsView.gameObject.SetActive(false);
    }

    public void BackToMenuFromCredits()
    {
        mainMenu.gameObject.SetActive(true);
        creditsView.gameObject.SetActive(false);
    }

    private void ReadRecord()
    {
        string fileName = "record.txt";
        string filepath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filepath))
        {
            StreamReader streamReader = new StreamReader(filepath);
            string record = streamReader.ReadLine();
            recordText.text = "Record: " + record;
            streamReader.Close();
            Debug.LogError("Record is: " + record);
        }
        else
        {
            recordText.text = "No Records Detected";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
