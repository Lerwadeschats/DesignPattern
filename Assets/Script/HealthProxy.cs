using UnityEngine;
public interface IHealth
{
    void OnTakeDamages(float value);
}
public class HealthProxy : MonoBehaviour, IHealth
{
    [SerializeField] CharacterStats _stats;

    public void OnTakeDamages(float value)
    {
        
       _stats.TakeDamages(value);
    }

    public void OnHeal(float value)
    {
        //heal
    }
}
