using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();


    }

    public void AttackAnimation()
    {
        _animator.SetTrigger("Attack");
    }

    public void HurtAnimation()
    {
        _animator.SetTrigger("Hit");
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger("Die");
    }

    public void WalkAnimation(float value)
    {
        _animator.SetFloat("WalkSpeed", value);
    }
}
