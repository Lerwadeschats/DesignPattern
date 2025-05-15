using Unity.Behavior;
using UnityEngine;
using UnityEngine.Events;


public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private HealthUI _healthBar;

    [SerializeField] CharacterAnimation _anim;
    [SerializeField] BehaviorGraphAgent _behaviour;

    public float Damage { get => _damage; set => _damage = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth; 
        set
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            _healthBar.updateSlider(value/MaxHealth);
            _currentHealth = value;
        } }
    public float Speed { get => _speed; set => _speed = value; }
    public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }

    void UpdateHealth(float value)
    {

        CurrentHealth += value;
        Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        if (CurrentHealth == 0)
        {
            Death();
        }
    }

    public void TakeDamages(float value)
    {
        UpdateHealth(-value);
        _anim.HurtAnimation();
    }

    public void Death()
    {
        if (_behaviour)
        {
            _behaviour.enabled = false;
        }
        _anim.DeathAnimation();
        //faire coroutine de mort
    }

}
