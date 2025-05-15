using UnityEngine;

public class MoneyItem : Item
{
    [SerializeField] int value = 5;
    public override void Pick(Collider collider)
    {
        MoneyProxy proxy = collider.GetComponent<MoneyProxy>();
        if (proxy != null) return;
        proxy.OnGetMoney(value);
        base.Pick(collider);
    }
}
