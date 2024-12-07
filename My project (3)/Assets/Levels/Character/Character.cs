using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("属性")]
    [SerializeField] protected float maxHealth;

    [SerializeField] protected float currentHealth;

    [Header("UI")]
    public UnityEvent<float, float>OnHealthUpdate;
    public bool invulnerable;
    public float invulnerableDuration;

    public UnityEvent OnHurt;
    public UnityEvent OnDie;
    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
       
    }
    private void Start()
    {
        OnHealthUpdate?.Invoke(maxHealth,currentHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        if(invulnerable)
         return;
        if(currentHealth-damage>0f)
        {
        currentHealth-=damage;
        StartCoroutine(nameof(InvulnerableCoroutine));//启动无敌时间协程
        //执行角色受伤动画
        OnHurt?.Invoke();
        }
       else
        {
            //死亡
            Die();
        }
         OnHealthUpdate?.Invoke(maxHealth,currentHealth);
    }
    public virtual void Die()
    {
        currentHealth =0f;
        //执行角色死亡动画
        OnDie?.Invoke();
        
       
    }

    //无敌
    protected virtual IEnumerator InvulnerableCoroutine()
    {
        invulnerable = true;
        yield return new WaitForSeconds(invulnerableDuration);
        invulnerable=false;

    }
}
