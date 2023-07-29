using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using DG.Tweening;

public class MonsterController : MonoBehaviour
{
    public event Action<GameObject> OnMonsterDestroyed;
    public event Action OnMonsterHit;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform monster;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;


    public Animator Animator => animator;

    private float health;
    private float speed;
    private int bulletDamage;

    private int isWalkingHash;
    private int isRunningHash;
    private int isGettingHit;
    private bool isWalking;
    private bool wPressed;
    private bool isRunning;
    private bool leftShiftPressed;

    private Vector3 monsterStartingPosition;

    // public float Speed => speed;

    private Vector3 targetPosition;
    private Vector3 monsterDirection;

    private System.Random random = new System.Random();
    private int randX;

    private void Start()
    {
        monsterStartingPosition = monster.position;
        animator.SetBool("isWalking", true);
        //animator.SetBool("isRunning", true);

        randX = random.Next(-5, 5);
        targetPosition = new Vector3(randX, 0, 1);
        RotateMonster();
    }


    private void Update()
    {
        if (health <= 0)
        {
            DestroyMonster();
        }

       /* isWalking = animator.GetBool(isWalkingHash);
        wPressed = Input.GetKey(KeyCode.W);
        isRunning = animator.GetBool(isRunningHash);
        leftShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (wPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (!wPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (wPressed && leftShiftPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!leftShiftPressed || !wPressed))
        {
            animator.SetBool(isRunningHash, false);
        }*/

        monster.position = Vector3.Lerp(monster.position, targetPosition, Time.deltaTime * speed);        
    }

    private void RotateMonster()
    {
        monsterDirection = targetPosition - monsterStartingPosition;
        float angle = Vector3.Angle(Vector3.right, monsterDirection);
        monster.eulerAngles = new Vector3(0, angle + 90, 0);
    }

    public void ChangeBulletDamage(int bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

    public void Setup(float health, float speed,Color color, int bulletDamage)
    {
        this.health = health;
        this.speed = speed;
        skinnedMeshRenderer.material.color = color;
        this.bulletDamage = bulletDamage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Monster collision");
        OnMonsterHit.Invoke();
        health = health - bulletDamage;
    }

    private void DestroyMonster()
    {
      //  injurySound.Play();
        Destroy(transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        OnMonsterDestroyed(gameObject);
    }
}
