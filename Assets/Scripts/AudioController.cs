using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource injurySound;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private AudioSource freezeSound;
    [SerializeField] private AudioSource gunUpgradeSound;
    [SerializeField] private AudioSource explosionSound;


    public void PlayMonsterHitSound()
    {
        injurySound.Play();
    }

    public void PlayShootSound()
    {
        shootSound.Play();
    }

    public void PlayFreezeSound()
    {
        freezeSound.Play();
    }

    public void PlayGunUpgradeSound()
    {
        gunUpgradeSound.Play();
    }

    public void PlayExplosionSound()
    {
        explosionSound.Play();
    }
}
