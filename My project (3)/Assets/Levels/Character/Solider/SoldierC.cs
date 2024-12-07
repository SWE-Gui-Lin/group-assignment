using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SoldierC : MonoBehaviour
{
    public Rigidbody2D theRB;
    public int value;
    public float moveSpeed;
    private SpriteRenderer sr;
    public bool isDead;
    public Animator myAnim;
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

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return; // 如果角色死亡，停止处理输入
        }
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*moveSpeed;
        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
        Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            myAnim.SetFloat("attackDirection", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("hitDirection", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("dieDirection", Input.GetAxisRaw("Horizontal"));
        }
       attack1();
       attack2();
       
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

    void attack1()
    {
        if(Input.GetButtonDown("attack1"))
        {
             myAnim.SetTrigger("attack1");
        }
    }
    void attack2()
    {
        if(Input.GetButtonDown("attack2"))
        {
             myAnim.SetTrigger("attack2");
        }
    }
     public void SoliderHurt()
  {
    myAnim.SetTrigger("hit");
  }
  
   public void SoliderDead()
  {
    isDead = true;
    myAnim.SetBool("isDie",isDead);
  }
}
