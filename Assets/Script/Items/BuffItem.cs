using UnityEngine;

public class BuffItem : Item
{
    [SerializeField] float factor = 1.5f;
    [SerializeField] float duration = 10;
    public override void Pick(Collider collider)
    {
        BuffProxy proxy = collider.GetComponent<BuffProxy>();
        if (proxy == null) return;
        proxy.OnAttackBuffed(factor, duration);
        base.Pick(collider);
    }
}
