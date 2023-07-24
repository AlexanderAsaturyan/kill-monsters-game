using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    [SerializeField] MonsterSpawner monsterSpawner;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Booster collision");
        Destroy(gameObject);
        foreach(var monster in monsterSpawner.Monsters)
        {
            Destroy(monster);
        }
    }
}
