using Unity.Behavior;
using UnityEngine;
using UnityEngine.Events;


public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
   

    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _attackCooldown = 1f;


    public float Damage { get => _damage; set => _damage = value; }

    public float Speed { get => _speed; set => _speed = value; }
    public float AttackCooldown { get => _attackCooldown; set => _attackCooldown = value; }
}
