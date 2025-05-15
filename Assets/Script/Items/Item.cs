using System;

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float _lifetimeDuration = 5f;
    public Action<Item> OnDeactivate;
    private CancellationTokenSource _cts;

    private void OnEnable()
    {
        _cts = new CancellationTokenSource();
    }

    public virtual void Pick(Collider collider)
    {
        _cts.Cancel();
        OnDeactivate.Invoke(this);
        

    }


    public void SpawnItem()
    {
        _cts = new CancellationTokenSource();
        Lifetime();
    }
    private void OnTriggerEnter(Collider other)
    {
        Pick(other);
    }

    async Task Lifetime()
    {
        await Awaitable.WaitForSecondsAsync(_lifetimeDuration, _cts.Token);
        OnDeactivate.Invoke(this);

    }
}
