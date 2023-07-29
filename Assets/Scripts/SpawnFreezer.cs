using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
