using System.Collections;
using Unity.Behavior;
using UnityEngine;

public class HealthMinions : Health, IDamageable
{
    [SerializeField] private Animator _animator;
    [SerializeField] BehaviorGraphAgent _behaviour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Death()
    {
        _behaviour.enabled = false;
        StartCoroutine(Dying());
    }
    IEnumerator Dying()
    {
        
        _animator.SetBool("Die", true);
        yield return new WaitForSeconds(3);
        //Spawn bonus
        Destroy(gameObject); //ou pas
        yield return null;
    }
    public void TakeDamage(float amount)
    {


        StartCoroutine(TakingDamage(amount));

    }
    IEnumerator TakingDamage(float amount)
    {
        _animator.SetBool("Hit", true);
        CurrentHealth -= amount;
        yield return new WaitForSeconds(1);
        _animator.SetBool("Hit", false);
        if (CurrentHealth < 0)
        {
            Death();
        }
        yield return null;
    }

}
