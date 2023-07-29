using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private GunUpgrader gunUpgrader;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private AudioController audioController;

    private Rigidbody bullet;


    private Vector2 turn;
    private float sensitivity = 5f;
    private float damage = 1;
    private float bulletSpeed = 70;
    public float Damage => damage;

    private bool isUpgraded;

    private void Start()
    {
        gunUpgrader.OnGunUpgraded += UpgradeGun;
    }

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.velocity = bulletSpawnPoint.forward * bulletSpeed;
            audioController.PlayShootSound();
           // var x = bullet.GetComponent<MeshRenderer>().material.color;
            if (isUpgraded)
            {
              //  x = Color.cyan;
                bullet.GetComponent<MeshRenderer>().material.color = Color.cyan;
            }

        }
    }

    private void UpgradeGun()
    {
        damage = 2;
        bulletSpeed = 100;
        meshRenderer.material.color = Color.green;
        isUpgraded = true;
        audioController.PlayGunUpgradeSound();
    }
}
