using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "TargetDetection", story: "Assign [Target] with [PlayerDetector]", category: "Action", id: "11e1045854718a4663266c29ec27a413")]
public partial class TargetDetectionAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<PlayerDetector> PlayerDetector;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Target.Value = PlayerDetector.Value.UpdateDetector();
        return Target.Value == null ? Status.Failure : Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

