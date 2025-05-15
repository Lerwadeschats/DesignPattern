using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth ;
    [SerializeField] private float _currentHealth ;
    [SerializeField] private HealthUI _healthBar;

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            _healthBar.updateSlider(value / MaxHealth);
            _currentHealth = value;
        }
    }
    // voir si on rajoute des fonctions en virtual
}
