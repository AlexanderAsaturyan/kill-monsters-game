using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;  
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private float smooth;
    [SerializeField] private float multiplier;
    [SerializeField] float sensitivity = 0.5f;

    private Vector2 turn;

    float mouseX;
    float mouseY;

    Quaternion rotationX;
    Quaternion rotationY;
    Quaternion targetRotation;

    private void Start()
    {
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        if (turn.x < 60 && turn.x > -60 && turn.y < 30 && turn.y > -30)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
       
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
