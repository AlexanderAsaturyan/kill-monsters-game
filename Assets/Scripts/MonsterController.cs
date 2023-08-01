using UnityEngine;
using System;

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

    private Vector3 monsterStartingPosition;
    private Vector3 targetPosition;
    private Vector3 monsterDirection;

    private System.Random random = new System.Random();
    private int randX;

    private void Start()
    {
        monsterStartingPosition = monster.position;
        animator.SetBool("isWalking", true);

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
        OnMonsterHit?.Invoke();
        health = health - bulletDamage;
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
