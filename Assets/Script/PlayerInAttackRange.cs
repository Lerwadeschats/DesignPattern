using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/PlayerInAttackRange")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "PlayerInAttackRange", message: "Damage", category: "Events", id: "27658500f815f7ca001ebf1f09706885")]
public partial class PlayerInAttackRange : EventChannelBase
{
    public delegate void PlayerInAttackRangeEventHandler();
    public event PlayerInAttackRangeEventHandler Event; 

    public void SendEventMessage()
    {
        Event?.Invoke();
    }

    public override void SendEventMessage(BlackboardVariable[] messageData)
    {
        Event?.Invoke();
    }

    public override Delegate CreateEventHandler(BlackboardVariable[] vars, System.Action callback)
    {
        PlayerInAttackRangeEventHandler del = () =>
        {
            callback();
        };
        return del;
    }

    public override void RegisterListener(Delegate del)
    {
        Event += del as PlayerInAttackRangeEventHandler;
    }

    public override void UnregisterListener(Delegate del)
    {
        Event -= del as PlayerInAttackRangeEventHandler;
    }
}

