using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private MonsterParent monster;
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GunController gun;
    [SerializeField] private GameoverPopup popup;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private bool gunDestroyed;

    private void Start()
    {
        popup.OnBackToMenuButtonClicked += GoToMenu;
        scoreText.text = $"Score: {score}";
       // backToMenuButton.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
       // Debug.Log("Monster count: " + monsterSpawner.Monsters.Count);
        if (monsterSpawner.MonstersCount == 10 && !gunDestroyed)
        {
           // Destroy(gun.gameObject);
          //  Destroy(monsterSpawner);
            foreach (var monster in monsterSpawner.Monsters)
            {
                if(monster.gameObject != null)
                {
                    monster.gameObject.SetActive(false);
                }
               // monsterSpawner.Monsters.Remove(monster);
                //Destroy(monster.gameObject);
            }
            monsterSpawner.gameObject.SetActive(false);
            popup.gameObject.SetActive(true);

            gunDestroyed = true;
        }

        if (score == 10)
        {
           // Debug.Log("Running");
            monster.MonsterController.Animator.SetBool("isRunning", true);
            monster.MonsterController.Animator.SetBool("isWalking", false);
            monster.MonsterController.speed = 4f;
          //  Debug.Log(monster.MonsterController.Animator.GetBool("isRunning"));
        }
    }

    public void IncrementPonits(GameObject monster)
    {
        if (monsterSpawner.MonstersCount == 10)
        {
            return;            
        }
        score++;
        scoreText.text = $"Score: {score}";
    }
}
