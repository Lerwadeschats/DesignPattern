using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] CharacterStats _stats;
    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    public void Activate()
    {
        _collider.isTrigger = true;
        //Animation
        Debug.Log("Activate");
    }

    public event Action OnHit;

    public void Deactivate()
    {
        _collider.isTrigger = false;
        Debug.Log("Deactivate");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollision");
        HealthProxy healthComponent = other.GetComponent<HealthProxy>();
        if (healthComponent == null) return;
        healthComponent.OnTakeDamages(_stats.Damage);
        OnHit?.Invoke();
    }
}
