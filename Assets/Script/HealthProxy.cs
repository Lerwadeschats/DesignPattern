using UnityEngine;

public class HealthProxy : MonoBehaviour
{
    [SerializeField] Health _health;

    public void OnTakeDamages(float value)
    {
        if(_health.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(value);
        }
    }
    public void OnHealDamages(float value)
    {
        if (_health.TryGetComponent(out IHealable healable))
        {
            healable.TakeHeal(value);
        }
    }
}
