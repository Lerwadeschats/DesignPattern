using System;

using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float _lifetimeDuration = 5f;
    public Action<Item> OnDeactivate;
    private CancellationTokenSource _cts;

    

    public virtual void Pick(Collider collider)
    {
        _cts.Cancel();
        OnDeactivate.Invoke(this);
        gameObject.SetActive(false);

    }


    public void SpawnItem()
    {
        gameObject.SetActive(false);
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
        gameObject.SetActive(false);

    }
}
