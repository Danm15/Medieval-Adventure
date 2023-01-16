using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalAbility : AbilityUpgrade
{
    private int _crtiticalDamage;
    private DamageType _damageType;

    public CriticalAbility(IAbility ability,int crtiticalDamage,DamageType damageType) : base(ability)
    {
        _crtiticalDamage = crtiticalDamage;
        _damageType = damageType;
    }

    public override void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        base.ApplyDamage(canBeDamaged);
        canBeDamaged.TakeDamage(DamageType.Critical, _crtiticalDamage);
    }
}
