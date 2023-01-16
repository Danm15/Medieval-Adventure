using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    
    
    void FixedUpdate()
    {
        transform.LookAt(_camera);
    }
}
