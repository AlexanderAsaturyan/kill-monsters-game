using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrader : MonoBehaviour
{
    public event Action OnGunUpgraded;

    private void OnCollisionEnter(Collision collision)
    {
        OnGunUpgraded.Invoke();
        Destroy(gameObject);
    }
}
