using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{    public Rigidbody2D theRB;
    public int value;
    public float moveSpeed;
    public Animator myAnim;
    private SpriteRenderer sr;

    public bool isDead;
    private void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        theRB = GetComponent<Rigidbody2D>();
    }
     void Update()
     {
         if (isDead)
        {
            return; // 如果角色死亡，停止处理输入
        }
         theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*moveSpeed;
         myAnim.SetFloat("MoveX", theRB.velocity.x);
         myAnim.SetFloat("MoveY", theRB.velocity.y);
         
         if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
         Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
         {
             myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
             myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
             myAnim.SetFloat("AttackDirection", Input.GetAxisRaw("Horizontal"));
             myAnim.SetFloat("HitDirection", Input.GetAxisRaw("Horizontal"));
             myAnim.SetFloat("DieDirection", Input.GetAxisRaw("Horizontal"));
         }
          Attack1();
          Attack2();
    
      }
      void Move()
      {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*moveSpeed;
        if(Input.GetAxisRaw("Horizontal")<0)
        {
            sr.flipX = true;
        }
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            sr.flipX = false;
        }
      }

     void Attack1()
    {
    if(Input.GetButtonDown("Attack1"))
      {
            myAnim.SetTrigger("Attack1");
      }
  }
   void Attack2()
     {
        if(Input.GetButtonDown("Attack2"))
       {
         myAnim.SetTrigger("Attack2");
       }
    }
  
  public void PlayerHurt()
  {
    myAnim.SetTrigger("Hit");
  }
   public void PlayerDead()
  {
    isDead = true;
    myAnim.SetBool("isDie",isDead);
    
  }
  
}
