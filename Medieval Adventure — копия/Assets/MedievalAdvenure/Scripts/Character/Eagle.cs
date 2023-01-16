using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Eagle : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private GameObject _focalPoint;


    private CharacterController _characterController;
    private float _checkGroundRadius = 1.3f;
    private bool _isGrounded;
    private bool _mouseInput;
    

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void FixedUpdate()
    {
        _isGrounded = IsOnGround();

       

        Move();
       
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    
    public void Transformation(GameObject gameObjectToRaplaceWith)
    {
        if (_isGrounded)
        {
            gameObjectToRaplaceWith.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            gameObjectToRaplaceWith.SetActive(true);
        }
        
    }

    public void Move(Vector3 direction, float horizontal, float vertical,  bool mouseInput)
    {
        _mouseInput = mouseInput;
    }

    

    private void Move()
    {
        transform.rotation = _focalPoint.transform.rotation;
        if(_mouseInput)
        _characterController.Move(transform.forward * Time.fixedDeltaTime * _speed);
    }


    private bool IsOnGround()
    {
        bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _groundMask);
        return result;
    }

    public void Jump()
    {

    }

}
