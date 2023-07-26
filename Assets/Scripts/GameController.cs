using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private MonsterParent monster;
    private int points = 0;


    private void Update()
    {
        if(points == 10)
        {
            Debug.Log("Running");
            monster.MonsterController.Animator.SetBool("isRunning", true);
            monster.MonsterController.Animator.SetBool("isWalking", false);
            monster.MonsterController.speed = 4f;
            Debug.Log(monster.MonsterController.Animator.GetBool("isRunning"));
        }
    }

    public void IncrementPonits()
    {
        points++;
        Debug.Log("Points " + points);
    }

}
