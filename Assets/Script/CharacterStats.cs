using UnityEngine;


public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _speed = 100f;

    public float GetSpeed()
    {
        return _speed;
    }

    void UpdateHealth(float value)
    {
        
        _currentHealth += value;
        Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void TakeDamages(float value)
    {
        UpdateHealth(-value);
    }

}
