using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MonoBehaviour
{
    public Rigidbody2D theRB;
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
        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
        Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
       attack1();
       attack2();
       
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
}
