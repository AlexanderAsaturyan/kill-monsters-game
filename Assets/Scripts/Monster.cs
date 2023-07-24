using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private MonsterController monsterController;
    public MonsterController MonsterController => monsterController;
}
