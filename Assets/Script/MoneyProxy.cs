using UnityEngine;

public class MoneyProxy : MonoBehaviour
{
    [SerializeField] CharacterStats _stats;

    public void OnGetMoney(int value)
    {

        _stats.GetMoney(value);
    }
}
