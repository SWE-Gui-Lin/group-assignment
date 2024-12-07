using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : Character
{public static Solider Instance {get; private set;}
    [Header("近战攻击")]
    public float meleeAttackDamage; // 近战攻击伤害
    public Vector2 attackSize = new Vector2(1f, 1f); // 攻击范围尺寸
    private Vector2 AttackAreaPos;
    public Animator myAnim;
    private SpriteRenderer spriteRenderer;
    public LayerMask enemyLayer;

    public float offsetX = 1f;
    public float offsetY = 1f;

    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

      void MeleeAttackAnimEvent(float isAttack)
    {
        UpdateAttackAreaPos();
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, enemyLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage * isAttack);
        }
    }

    private void UpdateAttackAreaPos()
    {
        float moveX = myAnim.GetFloat("attackDirection");
        AttackAreaPos = transform.position;

        if (moveX < 0)
        {
            AttackAreaPos.x -= Mathf.Abs(offsetX);
        }
        else if (moveX > 0)
        {
            AttackAreaPos.x += Mathf.Abs(offsetX);
        }

        AttackAreaPos.y += offsetY;
    }

    // 绘图用于测试
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        UpdateAttackAreaPos();
        Gizmos.DrawWireCube(AttackAreaPos, attackSize);
    }
}

