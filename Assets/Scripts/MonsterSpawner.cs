using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private SpawnFreezer spawnFreezer;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioController audioController;

    WaitForSeconds secondsForGenerateRandomSeconds = new WaitForSeconds(0.001f);

    private float speed = 0.2f;
    private float health = 1;
    private int difficultyLevel = 1;
    private Color color = Color.white;
    private int bulletDamage = 1;

    private void Start()
    {
        spawnFreezer.OnSpawnPaused += FreezeSpawn;
        StartCoroutine(GenerateRandomSeconds());
        StartCoroutine(InstantiateMonster());
    }

    public void SetMonsterSpecs(float health, float speed, int difficultyLevel, Color color)
    {
        this.health = health;
        this.speed = speed;
        this.difficultyLevel = difficultyLevel;
        this.color = color;
    }

    public void ChangeBulletDamage(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    private System.Random random = new System.Random();
    private int randX;
    private int randZ;

    private float delayTime;
    private float randomSeconds;
    private bool canSpawn = true;
    private int monstersCount = 0;
    public int MonstersCount => monstersCount;

    private List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> Monsters => monsters;

    private IEnumerator GenerateRandomSeconds()
    {
        while (true)
        {
            yield return secondsForGenerateRandomSeconds;

            if(difficultyLevel == 1)
            {
               randomSeconds = (float)random.Next(5, 20) / 10;
            }
            else if(difficultyLevel == 2)
            {
                randomSeconds = (float)random.Next(5, 20) / 10 / 1.5f;
            }
        }
    }

    private async void FreezeSpawn()
    {
        canSpawn = false;
        audioController.PlayFreezeSound();
        await Task.Delay(3000);
        canSpawn = true;
    }

    private void RemoveMonsterFromList(GameObject monster)
    {
        monsters.Remove(monster);
        monstersCount--;
    }

    private IEnumerator InstantiateMonster()
    {
        while (true)
        {
            if (canSpawn)
            {
                yield return new WaitForSeconds(randomSeconds);
                randX = random.Next(-5, 5);
                randZ = random.Next(10, 15);
                GameObject monsterGO = Instantiate(monsterPrefab, new Vector3(randX, 0, randZ), Quaternion.identity);
                monsterGO.transform.eulerAngles = new Vector3(0, 90, 0);
                MonsterParent monster = monsterGO.GetComponent<MonsterParent>();
                monster.MonsterController.OnMonsterDestroyed += gameController.IncrementScore;
                monster.MonsterController.OnMonsterDestroyed += RemoveMonsterFromList;

                monsters.Add(monsterGO);
                monstersCount++;
                monster.MonsterController.Setup(health, speed, color, bulletDamage);
                monster.MonsterController.OnMonsterHit += audioController.PlayMonsterHitSound;             
            }

            else
            {
                yield return null;
            }
        }
    }
}