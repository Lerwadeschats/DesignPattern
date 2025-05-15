using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SwordBool", story: "[Sword] is [active]", category: "Action", id: "54c2150a182634359f8c2e2392fdecf1")]
public partial class SwordBoolAction : Action
{
    [SerializeReference] public BlackboardVariable<Sword> Sword;
    [SerializeReference] public BlackboardVariable<bool> Active;
    protected override Status OnStart()
    {
        if (Active.Value==true)
        {
            Sword.Value.Activate();
        }
        else if (Active.Value==false)
        {
            Sword.Value.Deactivate();
        }
        return Status.Success;
    }

    
}

