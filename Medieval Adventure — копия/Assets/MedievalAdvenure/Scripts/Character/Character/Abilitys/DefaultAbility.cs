using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAbility : IAbility
{
    private int _damage;
    private DamageType _damageType;

    public DefaultAbility(int damage , DamageType damageType)
    {
        _damage = damage;
        _damageType = damageType;
    }

    public void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        canBeDamaged.TakeDamage(_damageType,_damage);
    }

    public int GetDamage()
    {
        return _damage;
    }

    public DamageType GetDamageType()
    {
        return _damageType;
    }

    
}
