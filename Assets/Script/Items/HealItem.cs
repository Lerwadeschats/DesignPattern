using UnityEngine;

public class Heal : Item
{
    [SerializeField] float amount = 10f;
    public override void Pick(Collider collider)
    {
        base.Pick(collider);
        HealthProxy healthComponent = collider.GetComponent<HealthProxy>();
        if (healthComponent == null) return;
        //Heal
        base.Pick(collider);
    }
}
