using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Player in Sight", story: "[Player] is in [Sight]", category: "Conditions", id: "b32cd727a88518fbcb2972f5dc684643")]
public partial class PlayerInSightCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<LineOfSight> Sight;

    public override bool IsTrue()
    {
        return Sight.Value.Detection(Player.Value)==Player;
    }

}
