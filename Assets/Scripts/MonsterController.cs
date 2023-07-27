using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public event Action<GameObject> OnMonsterDestroyed;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform monster;
    [SerializeField] private GameController gameController;

    public Animator Animator => animator;

    public float health;
    public float speed;

    private int isWalkingHash;
    private int isRunningHash;
    private int isGettingHit;
    private bool isWalking;
    private bool wPressed;
    private bool isRunning;
    private bool leftShiftPressed; 

    public void SetHealthAndSpeed(float health, float speed)
    {
        this.health = health;
        this.speed = speed;
    }


   // public float Speed => speed;

    private Vector3 targetPosition;

    private System.Random random = new System.Random();
    private int randX;

    private void Start()
    {
        animator.SetBool("isWalking", true);
        //animator.SetBool("isRunning", true);

        randX = random.Next(-5, 5);
        targetPosition = new Vector3(randX, 0, 1);
    }


    private void Update()
    {
      //  Debug.Log(animator.GetBool("isWalking"));
        /* if (Input.GetKey(KeyCode.W))
         {
             animator.SetBool("isWalking", true);
         }*/

       // animator.SetBool(isWalkingHash, true);

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

        monster.transform.position = Vector3.Lerp(monster.transform.position, targetPosition, Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Monster collision");
        health--;
    }

    private void DestroyMonster()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        OnMonsterDestroyed(gameObject);
    }
}
