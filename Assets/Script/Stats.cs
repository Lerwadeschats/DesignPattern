using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] internal float _damage = 5f;

    [SerializeField] internal float _speed = 100f;
    [SerializeField] internal float _attackCooldown = 1f;
    public float Damage { get => _damage; set => _damage = value; }

    public float Speed { get => _speed; set => _speed = value; }
    public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }

}
