using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Character _character;
    [SerializeField] private float yRotation = 0f;
    [SerializeField] private float xRotation = 0f;

   
    private float _smoothing = 5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
       if(!PlayerHealthPoints.GameOver)
            CameraMove();


    }
    public void CameraMove(float mouseX,float mouseY)
    {
        yRotation -= mouseY;
        xRotation -= mouseX;
    }
    public void GetNewTarget(Transform targetTransform)
    {
        _targetTransform = targetTransform;
    }

    private void CameraMove()
    {
        yRotation = Mathf.Clamp(yRotation, -45, 45);
        _character.GetYRotation(xRotation);
        transform.rotation = Quaternion.Euler(yRotation, xRotation, 0);
        var nextPosition = Vector3.Lerp(transform.position,_targetTransform.position,Time.fixedDeltaTime * _smoothing);
        transform.position = nextPosition;
    }
}
