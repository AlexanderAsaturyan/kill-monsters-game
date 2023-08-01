using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private AudioController audioController;

    private void OnCollisionEnter(Collision collision)
    {
        audioController.PlayExplosionSound();
        Destroy(gameObject);
        foreach(var monster in monsterSpawner.Monsters)
        {
            Destroy(monster);
        }
    }
}
