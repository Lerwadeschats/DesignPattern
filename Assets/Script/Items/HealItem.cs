using UnityEngine;

public class Heal : Item
{
    [SerializeField] float amount = 10f;
    public override void Pick(Collider collider)
    {
        base.Pick(collider);
        HealthProxy proxy = collider.GetComponent<HealthProxy>();
        if (proxy == null) return;
        proxy.OnHealDamages(amount);
        base.Pick(collider);
    }
}
