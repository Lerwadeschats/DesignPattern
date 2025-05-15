using System.Collections;
using UnityEngine;

public class HealthPlayer : Health,IDamageable,IHealable
{
    [SerializeField] private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Death()
    {
        StartCoroutine(Dying());
    }
    IEnumerator Dying()
    {
        _animator.SetBool("Diying", true);
        yield return new WaitForSeconds(3);
        //Spawn bonus
        Destroy(gameObject); //ou pas
        yield return null;
    }

    public void TakeHeal(float amount)
    {
        CurrentHealth += amount;
    }
    public void TakeDamage(float amount)
    {
        _animator.SetBool("Hit", true);
        CurrentHealth -= amount;
        if (CurrentHealth < 0)
        {
            Death();
        }
        _animator.SetBool("Hit", false);
    }
}
