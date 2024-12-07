using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

public class EnemyHealth : Character
{
   public UnityEvent<Vector2> OnMovementInput;
   public UnityEvent OnAttack;
    [SerializeField]private Transform player;
    [SerializeField]private float chaseDistance  = 3f;
    [SerializeField]private float attackDistance  = 0.8f;
    //自动寻路
    private Seeker seeker;
    private List<Vector3> pathPointList;
    private int currentIndex =0;
    private float pathGenerateInterval =0.5f;
    private float pathGenerateTimer =0f;
    [Header("攻击")]
    public float meleeAttackDamage;
    public LayerMask playerLayer;
    public float AttackCooldownDuration = 2f;
    private bool isAttack =true;

    private void Awake()
    {
        seeker = GetComponent<Seeker>();
    }
    private void Update()
    {
        if(player == null)
        {
            return;
        }

        float distance =Vector2.Distance(player.position,transform.position);

        if(distance<chaseDistance)
        {
            AutoPath();
            if(pathPointList == null)
               return;
            if(distance<=attackDistance)
            {
                //攻击玩家
                OnMovementInput?.Invoke(Vector2.zero);
                OnAttack?.Invoke();
            }
            else
            {
                //追击玩家
                //Vector2 direction = player.position - transform.position;
                Vector2 direction = (pathPointList[currentIndex]-transform.position).normalized;
                OnMovementInput?.Invoke(direction);//移动方向传给enemycontroller脚本
            }
        }
        else
        {
            //放弃追击
            OnMovementInput?.Invoke(Vector2.zero);
        }
    }

    public void MeleeAttackAnimEvent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position,attackDistance,playerLayer);

        foreach(Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage);

        }
    }
    //自动寻路
    private void AutoPath()
    {
        pathGenerateTimer += Time.deltaTime;
        //间隔一些时间来获取路径
        if(pathGenerateTimer>=pathGenerateInterval)
        {
            GeneratePath(player.position);
            pathGenerateTimer=0;
        }
        if(pathPointList == null || pathPointList.Count <= 0)
        {
            GeneratePath(player.position);
        }
        else if(Vector2.Distance(transform.position,pathPointList[currentIndex])<=0.1f)
        {
            currentIndex++;
            if(currentIndex>=pathPointList.Count)
            GeneratePath(player.position);
        }
    }
    //获取路径点
    private void GeneratePath(Vector3 target)
    {
        currentIndex =0;
        seeker.StartPath(transform.position,target,path=>
        {
            pathPointList = path.vectorPath;
        });
    }
    private void OnDrawGizmosSelected()
    {
        //攻击范围
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackDistance);
    }

}
