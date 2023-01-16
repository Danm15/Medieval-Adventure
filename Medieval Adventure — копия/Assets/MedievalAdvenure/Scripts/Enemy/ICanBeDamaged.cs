using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanBeDamaged 
{
    void TakeDamage(DamageType type, int damage);
    
}
