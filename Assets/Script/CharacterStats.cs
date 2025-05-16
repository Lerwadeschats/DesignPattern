using System.Threading.Tasks;
using Unity.Behavior;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class CharacterStats : Stats,IBuffable
{
    private float _money;
    [SerializeField] private TMP_Text _moneyUI;



    public float Money { 
        get => _money;
        set
        {
            if(value < 0)
            {
                value = 0;
            }
            if (_moneyUI)
            {
                _moneyUI.text = " coins : " + value;

            }
            _money = value;
        }
    }

    public TMP_Text MoneyUI => throw new System.NotImplementedException();

    private void Start()
    {
        Money = 0;
    }
    public void GetBuffed(float factor, float duration)
    {
        Buff(factor, duration);
    }

    async Task Buff(float factor, float duration)
    {
        _damage *= factor;
        await Awaitable.WaitForSecondsAsync(duration);
        _damage /= factor;
    }

    public void GetMoney(int amount)
    {
        Money += amount;
        
    }

}
