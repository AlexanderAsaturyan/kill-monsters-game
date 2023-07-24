using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject spawnFreezer;
    [SerializeField] private GameController gameController;


    private System.Random random = new System.Random();
    private int randX;
    private int randZ;
    private Quaternion monsterRotation = new Quaternion(0, 180, 0, 0);
    private float randomSeconds;

    private List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> Monsters => monsters;



    private void Start()
    {
        StartCoroutine(GenerateRandomSeconds());
        StartCoroutine(InstantiateMonster());
        StartCoroutine(PlayMonstersVoices());
    }

    private void Update()
    {
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
        if(monsters.Count >=5)
        {
            Debug.Log("5+");
            // monsters voices code here
            yield return new WaitForSeconds(2);
        }
    }

    private IEnumerator GenerateRandomSeconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            randomSeconds = (float)random.Next(5, 20) / 10;
        }
    }

    private IEnumerator InstantiateMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomSeconds);
            randX = random.Next(-10, 10);
            randZ = random.Next(5, 20);
            GameObject monsterGO = Instantiate(monsterPrefab, new Vector3(randX, 0, randZ), monsterRotation);
            Monster monster = monsterGO.GetComponent<Monster>();
            monster.MonsterController.OnMonsterKilled += gameController.IncrementPonits;
            monsters.Add(monsterGO);
        } 
    }
}
