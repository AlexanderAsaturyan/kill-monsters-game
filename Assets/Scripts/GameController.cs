using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Monster monster;
    private int points = 0;


    private void Update()
    {
        if(points == 10)
        {
            Debug.Log("Running");
            monster.MonsterController.Animator.SetBool("isWalking", true);
            monster.MonsterController.speed = 4f;
        }
    }

    public void IncrementPonits()
    {
        points++;
        Debug.Log(points);
    }

}
