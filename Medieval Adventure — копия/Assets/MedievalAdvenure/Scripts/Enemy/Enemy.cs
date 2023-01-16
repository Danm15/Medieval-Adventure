using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public  class Enemy : MonoBehaviour,ICanBeDamaged
{
    [SerializeField]private Slider _enemyHealthPointsSlider;
    [SerializeField] private UIController _lossOfHealthPoints;
    private int _enemyHealthPoints = 200;
    private Animator _enemyAnimator;
   

    // Start is called before the first frame update
    void Start()
    {
        _enemyHealthPointsSlider.maxValue = _enemyHealthPoints;
        _enemyAnimator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemyHealthPointsSlider.value = _enemyHealthPoints;
        if (PlayerHealthPoints.GameOver)
        {
            _enemyAnimator.enabled = false;
           
           
        }

    }

    public void TakeDamageMy(int damageAmount)
    {
        _enemyHealthPoints -= damageAmount;

        if(_enemyHealthPoints <= 0)
        {
            _enemyAnimator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            _enemyHealthPointsSlider.gameObject.SetActive(false);
            StartCoroutine(DestroyDelay());
        }
        else
        {
            _enemyAnimator.SetTrigger("TakeDamage");
        }
    }

    public void TakeDamage(DamageType type, int damage)
    {
        _lossOfHealthPoints.CreateWidgetDamageValue(type, damage);
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSecondsRealtime(10);
       Destroy(gameObject);
    }

}
