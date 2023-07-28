using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletSpeed = 10;

    private float sensitivity = 5f;
    private Vector2 turn;

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
