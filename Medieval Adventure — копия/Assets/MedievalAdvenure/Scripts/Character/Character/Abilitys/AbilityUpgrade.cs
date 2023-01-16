using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityUpgrade :  IAbility
{
    protected IAbility MainAbility;

    public AbilityUpgrade(IAbility ability)
    {
        MainAbility = ability;
    }

    public virtual int GetDamage()
    {
        return MainAbility.GetDamage();
    }

    public virtual DamageType GetDamageType()
    {
        return MainAbility.GetDamageType();
    }

    public virtual void ApplyDamage(ICanBeDamaged canBeDamaged)
    {
        MainAbility.ApplyDamage(canBeDamaged);
    }

}
