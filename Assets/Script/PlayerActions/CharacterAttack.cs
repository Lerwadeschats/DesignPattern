using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAttack : MonoBehaviour
{

    [SerializeField] Sword _sword;
    [SerializeField] CharacterStats _stats;

    [SerializeField] CharacterAnimation _anim;


    private CancellationTokenSource _cts;

    bool _canAttack = true;
    private void Start()
    {
        _cts = new CancellationTokenSource();
        _sword.OnHit += OnHit;
    }
    public void Attack()
    {
        if (_canAttack)
        {
            _sword.Activate();
            _anim.AttackAnimation();
            AttackCooldown(_cts.Token);
        }
        
        
    }

    async Task AttackCooldown(CancellationToken token)
    {
        
        _canAttack = false;
        await Awaitable.WaitForSecondsAsync(_stats.AttackCooldown, token);
        _sword.Deactivate();
        _canAttack = true;
        
    }

    void OnHit()
    {
        _sword.Deactivate();
    }
}
