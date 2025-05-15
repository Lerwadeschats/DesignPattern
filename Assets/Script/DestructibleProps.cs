using Unity.AI.Navigation;
using UnityEngine;

public class DestructibleProps : Health,IDamageable
{
    [SerializeField]NavMeshSurface _navMeshSurface;
    public void Death()
    {
        //spawn thing
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
