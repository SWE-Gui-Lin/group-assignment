using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{    public Rigidbody2D theRB;
    public int value;
    public float moveSpeed;
    public Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*moveSpeed;
        myAnim.SetFloat("MoveX", theRB.velocity.x);
        myAnim.SetFloat("MoveY", theRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
        Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
        Attack1();
        Attack2();
    
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
  
}
