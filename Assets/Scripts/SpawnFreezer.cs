using System;
using UnityEngine;

public class SpawnFreezer : MonoBehaviour
{
    public event Action OnSpawnPaused;

    private void OnCollisionEnter(Collision collision)
    {
        OnSpawnPaused?.Invoke();;
        Destroy(gameObject);
    }
}
