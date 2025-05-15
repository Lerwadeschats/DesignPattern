using UnityEngine;
using UnityEngine.Events;


public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _attackCooldown = 1f;

    [SerializeField] CharacterAnimation _anim;

    public float Damage { get => _damage; set => _damage = value; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }

    void UpdateHealth(float value)
    {
        
        _currentHealth += value;
        Mathf.Clamp(_currentHealth, 0, _maxHealth);
        if (_currentHealth == 0)
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
       _anim.DeathAnimation();
    }

}
