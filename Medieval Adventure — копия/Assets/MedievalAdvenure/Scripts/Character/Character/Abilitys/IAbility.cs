using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility 
{
    int GetDamage();
    DamageType GetDamageType();
    void ApplyDamage(ICanBeDamaged canBeDamaged);
}
