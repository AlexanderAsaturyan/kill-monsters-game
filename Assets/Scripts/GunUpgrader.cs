using System;
using UnityEngine;

public class GunUpgrader : MonoBehaviour
{
    public event Action OnGunUpgraded;

    private void OnCollisionEnter(Collision collision)
    {
        OnGunUpgraded?.Invoke();
        Destroy(gameObject);
    }
}
