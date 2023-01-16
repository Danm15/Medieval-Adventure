using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    void Move(Vector3 direction,float horizontal , float vertical,bool mouseInput);
    void Transformation(GameObject gameObjectToRaplaceWith);
    void Jump();
    void Attack();
}
