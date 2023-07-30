using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Threading;
using System.IO;

public class GameController : MonoBehaviour
{
    [SerializeField] private MonsterParent monster;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GunController gun;
    [SerializeField] private GameoverPopup popup;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GunUpgrader gunUpgrader;
    [SerializeField] private AudioSource gameplayMusic;

    private int score = 0;
    private int recordScore;

    private bool gunDestroyed;

    private void Start()
    {
        //  monster.MonsterController.speed = 0.2f;
        //  monster.MonsterController.health = 2f;
        gameplayMusic.Play();
        popup.OnBackToMenuButtonClicked += GoToMenu;
        scoreText.text = $"Score: {score}";
        gunUpgrader.OnGunUpgraded += UpgradeGun;
    }

    private void UpgradeGun()
    {
        monsterSpawner.ChangeBulletDamage(2);
        foreach (var monster in monsterSpawner.Monsters)
        {
            if (monster != null)
            {
                var canGetComponent = monster.TryGetComponent<MonsterController>(out MonsterController monsterController);
                if (canGetComponent)
                {
                    monsterController.ChangeBulletDamage(2);
                }
            }
        }
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        // Debug.LogError(monsterSpawner.randomSeconds);
        // Debug.LogError(monster.MonsterController.speed);
        if (monsterSpawner.MonstersCount == 10 && !gunDestroyed)
        {
            Destroy(gun.gameObject);

            foreach (var monster in monsterSpawner.Monsters)
            {
                if (monster.gameObject != null)
                {
                    monster.gameObject.SetActive(false);
                }
            }

            monsterSpawner.gameObject.SetActive(false);
            popup.PopupScoreText.text = scoreText.text;
            popup.gameObject.SetActive(true);
            gunDestroyed = true;
            SaveRecordScore();
        }
    }

    private void ChangeGameDifficulty()
    {
        // monster.MonsterController.speed = 0.8f;
        // monster.MonsterController.health = 4;
        // monsterSpawner.randomSeconds = monsterSpawner.randomSeconds * 100f;
        //monster.MonsterController.SkinnedMeshRenderer.material.color = Color.red;
        monsterSpawner.SetMonsterSpecs(2f, 0.4f, 2, Color.red);
    }

    private void SaveRecordScore()
    {
        string filepath = "record.txt";
        int record = 0;

        StreamReader streamReader = new StreamReader(filepath);
        string recordString = streamReader.ReadLine();
        streamReader.Close();

        if (!string.IsNullOrEmpty(recordString))
        {
            record = int.Parse(recordString);
        }



        if (score > record)
        {
            StreamWriter streamWriter = new StreamWriter(filepath);
            streamWriter.Write(score);
            streamWriter.Close();
        }
    }

    public void IncrementScore(GameObject monsterr)
    {
        if (monsterSpawner.MonstersCount == 10)
        {
            return;
        }

        score++;
        scoreText.text = $"Score: {score}";

        if (score == 10)
        {
            ChangeGameDifficulty();
            if (gunUpgrader != null)
            {
                gunUpgrader.gameObject.SetActive(true);
            }
        }
    }
}