using UnityEngine;
public class BuffProxy : MonoBehaviour
{
    [SerializeField] CharacterStats _stats;

    public void OnAttackBuffed(float factor, float duration)
    {
        
       _stats.GetBuffed(factor, duration);
    }
}
