using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("属性")]
    [SerializeField]private float currentSpeed =0;

    [Header("攻击")]
    [SerializeField]private bool isAttack =true;
    [SerializeField]private float attackCoolDuration=1;


    public Vector2 MovementInput { get; set; }
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(!isDead)
        Move();
        SetAnimation();
    }
    void Move()
    {
        if(MovementInput.magnitude>0.1f && currentSpeed >=0)
        {
        rb.velocity= MovementInput * currentSpeed;
        //翻转
        if(MovementInput.x<0)
        {
            sr.flipX=false;
        }
        if(MovementInput.x>0)
        {
            sr.flipX=true;
        }
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
    
    public void Attack()
    {
        if(isAttack)
        {
            isAttack=false;
            StartCoroutine(nameof(AttackCoroutine));
        }
    }
    IEnumerator AttackCoroutine()
    {
        anim.SetTrigger("isAttack");
        yield return new WaitForSeconds(attackCoolDuration);
        isAttack =true;
    }

    public void EnenyHurt()
    {
        anim.SetTrigger("isHurt");
    }

    public void EnemyDead()
    {
        isDead=true;
    }
    void SetAnimation()
    {
        anim.SetBool("isWalk",MovementInput.magnitude>0);
        anim.SetBool("isDead",isDead);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

}
