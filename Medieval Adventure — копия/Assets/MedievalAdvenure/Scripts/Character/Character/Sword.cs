using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private int _damageAmount;
    private int _hits;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _hits++;
            _damageAmount = Random.Range(10, 30);
            IAbility ability = new DefaultAbility(_damageAmount, DamageType.Physical);
            other.GetComponent<Enemy>().TakeDamageMy(_damageAmount);
            if (_hits > 2)
            {
                _damageAmount = Random.Range(50, 70);
                ability = new CriticalAbility(ability, _damageAmount, DamageType.Critical);
                other.GetComponent<Enemy>().TakeDamageMy(_damageAmount);
                _hits = 0;
            }
           
            ability.ApplyDamage(other.GetComponent<Enemy>());
        }
    }
}
