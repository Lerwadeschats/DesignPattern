using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] CharacterStats _playerStats;

    [SerializeField] float _rotationSpeed = 1f;

    Rigidbody _rigidbody;
    NavMeshAgent _navMeshAgent;

    Vector3 _direction = Vector3.zero;

    Quaternion _rotationDirection;

    public Vector3 Direction { get => _direction; set => _direction = value; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //A changer
        _navMeshAgent = GetComponent<NavMeshAgent>(); //A changer
        
    }

    public void Move()
    {

        _navMeshAgent.speed = _playerStats.Speed;
        Vector3 newDirection = _direction;
        if (_direction != Vector3.zero)
        {
            _rotationDirection = Quaternion.LookRotation(newDirection);
        }
        _navMeshAgent.SetDestination(_rigidbody.position + newDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotationDirection, Time.fixedDeltaTime * (_rotationSpeed * _navMeshAgent.speed));

    }

}
