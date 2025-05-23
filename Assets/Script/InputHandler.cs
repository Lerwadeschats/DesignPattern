using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputHandler : MonoBehaviour
{
    PlayerInput _inputs;

    InputAction _movementAction;
    InputAction _attackAction;



    [SerializeField] CharacterMovement _movements;
    [SerializeField] CharacterAttack _attack;

    public PlayerInput InputsPlayer { get => _inputs; set => _inputs = value; }



    private void OnEnable()
    {
        _inputs = GetComponent<PlayerInput>();

    }

    private void Start()
    {
        _movementAction = _inputs.actions.FindAction("Move");
        _movementAction?.Enable();

        _attackAction = _inputs.actions.FindAction("Attack");
        _attackAction?.Enable();

    }

    private void FixedUpdate()
    {
        Vector3 direction = _movementAction.ReadValue<Vector2>();
        _movements.Direction = Quaternion.Euler(0, -45, 0) * new Vector3(direction.x, 0, direction.y);
        _movements.Move();
    }


}
