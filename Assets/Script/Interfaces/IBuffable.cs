using System.Collections;
using TMPro;
using UnityEngine;

public interface IBuffable//l'argent est considéré comme un buff
{
    public TMP_Text MoneyUI { get; }
    public float Money { get; set; }
    public void GetBuffed(float factor, float duration);

    public void GetMoney(int amount);

}
