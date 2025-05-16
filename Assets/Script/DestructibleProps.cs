using System.Threading.Tasks;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class DestructibleProps : Health,IDamageable
{
    [SerializeField]NavMeshSurface _navMeshSurface;
    Drop _drop;

    private void OnEnable()
    {
        _drop = GetComponent<Drop>();
    }
    public void Death()
    {
        //spawn thing
        _drop.SpawnDrop();
        Destroy(gameObject);
        //TimeBeforeDestroy();
    }

    async Task TimeBeforeDestroy()
    {
        await Awaitable.WaitForSecondsAsync(0.5f);
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        Death();
    }

    private void OnDestroy()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
