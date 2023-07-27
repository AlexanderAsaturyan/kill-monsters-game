using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private SpawnFreezer spawnFreezer;
    [SerializeField] private GameController gameController;


    WaitForSeconds waitForTwoSeconds = new WaitForSeconds(2);


    private System.Random random = new System.Random();
    private int randX;
    private int randZ;
    private Quaternion monsterRotation = new Quaternion(0, 180, 0, 0);

    private float delayTime;
    private float randomSeconds;
    private bool canSpawn = true;
    private int monstersCount = 0;
    public int MonstersCount => monstersCount;

    private List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> Monsters => monsters;


    private void Start()
    {
       // delayTime = randomSeconds;
        spawnFreezer.OnSpawnPaused += FreezeSpawn;
        StartCoroutine(GenerateRandomSeconds());
        StartCoroutine(InstantiateMonster());
        // StartCoroutine(PlayMonstersVoices());
    }

    private void Update()
    {
        //Debug.Log("Can Spawn: " + canSpawn);
      //  Debug.Log($"Delay time: {delayTime}");

        if (monsters.Count == 10)
        {
            // Debug.Log("You lose!!! 10 monsters");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator PlayMonstersVoices()
    {

        if (monsters.Count >= 5)
        {
            Debug.Log("5+");
            // monsters voices code here
            yield return waitForTwoSeconds;
        }

    }

    private IEnumerator GenerateRandomSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            randomSeconds = (float)random.Next(5, 20) / 10;
           // delayTime = randomSeconds;
        }
    }

    private async void FreezeSpawn()
    {
        canSpawn = false;
        await Task.Delay(3000);
        canSpawn = true;
    }

    private void RemoveMonsterFromList(GameObject monster)
    {
        monsters.Remove(monster);
        monstersCount--;
        Debug.LogError("monster removed. Monsters.Count: " + monsters.Count);
    }

    private IEnumerator InstantiateMonster()
    {
        while (true)
        {
            if (canSpawn)
            {
                yield return new WaitForSeconds(randomSeconds);
                randX = random.Next(-10, 10);
                randZ = random.Next(5, 20);
                GameObject monsterGO = Instantiate(monsterPrefab, new Vector3(randX, 0, randZ), monsterRotation);
                MonsterParent monster = monsterGO.GetComponent<MonsterParent>();
                monster.MonsterController.OnMonsterDestroyed += gameController.IncrementScore;
                monster.MonsterController.OnMonsterDestroyed += RemoveMonsterFromList;

                monsters.Add(monsterGO);
                monstersCount++;
                Debug.Log("Monster spawned");
            }

            else
            {
                yield return null;
            }
        }
    }
}