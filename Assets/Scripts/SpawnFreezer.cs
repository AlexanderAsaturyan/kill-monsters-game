using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFreezer : MonoBehaviour
{
    public event Action OnSpawnPaused;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("PAUSE SPAWN");
        OnSpawnPaused?.Invoke();
        Destroy(gameObject);
    }
}
