using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private AudioController audioController;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Booster collision");
        audioController.PlayExplosionSound();
        Destroy(gameObject);
        foreach(var monster in monsterSpawner.Monsters)
        {
           // monsterSpawner.Monsters.Remove(monster);
            Destroy(monster);
        }
    }
}
