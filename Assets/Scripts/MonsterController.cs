using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    //public event Action OnMonsterKilled;
    public event Action<GameObject> OnMonsterDestroyed;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform monster;

    public Animator Animator => animator;

    private float health = 2;

    private int isWalkingHash;
    private int isRunningHash;
    private int isGettingHit;
    private bool isWalking;
    private bool wPressed;
    private bool isRunning;
    private bool leftShiftPressed;
    public float speed = 0.2f;

   // public float Speed => speed;

    private Vector3 targetPosition;

    private System.Random random = new System.Random();
    private int randX;

    private void Start()
    {
        animator.SetBool("isWalking", true);

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
        health = health - 2;
    }

    private void DestroyMonster()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnDestroy()
    {
        //OnMonsterKilled?.Invoke();
        OnMonsterDestroyed(gameObject);
    }
}
