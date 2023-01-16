using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealBottle : MonoBehaviour
{
    public static event Action OnHealCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnHealCollected?.Invoke();
        }
    }
}
