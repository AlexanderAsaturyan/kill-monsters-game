using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private MonsterParent monster;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GunController gun;
    [SerializeField] private GameoverPopup popup;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int score = 0;

    private bool gunDestroyed;

    private void Start()
    {
        monster.MonsterController.speed = 0.2f;
        monster.MonsterController.health = 2f;
        popup.OnBackToMenuButtonClicked += GoToMenu;
        scoreText.text = $"Score: {score}";
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        Debug.LogError(monsterSpawner.randomSeconds);
       // Debug.LogError(monster.MonsterController.speed);
        if (monsterSpawner.MonstersCount == 10 && !gunDestroyed)
        {
            Destroy(gun.gameObject);

            foreach (var monster in monsterSpawner.Monsters)
            {
                if(monster.gameObject != null)
                {
                    monster.gameObject.SetActive(false);
                }
            }

            monsterSpawner.gameObject.SetActive(false);
            popup.PopupScoreText.text = scoreText.text;
            popup.gameObject.SetActive(true);
            gunDestroyed = true;
        }
    }

    private void ChangeGameDifficulty()
    {
        monster.MonsterController.speed = 0.8f;
        monster.MonsterController.health = 4;
        // monsterSpawner.randomSeconds = monsterSpawner.randomSeconds * 100f;
        monsterSpawner.SetDifficulty(4f, 0.8f, 2);
    }


    public void IncrementScore(GameObject monsterr)
    {
        if (monsterSpawner.MonstersCount == 10)
        {
            return;            
        }

        score++;
        scoreText.text = $"Score: {score}";

        if(score == 5) 
        {
            ChangeGameDifficulty();
        }
    }
}
