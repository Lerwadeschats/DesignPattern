using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Agent] is [Attacking] .", category: "Action", id: "c97c238241a19d70d078b5cac6d758bf")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<PlayerAttacks> Attacking;

    protected override Status OnStart()
    {
        //Attacking do things
        return Status.Running;
    }

}

