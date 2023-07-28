using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterParent : MonoBehaviour
{
    [SerializeField] private MonsterController monsterController;
  
    public MonsterController MonsterController => monsterController;
}
