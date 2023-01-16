using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public  class Character : MonoBehaviour,IControllable
{
    
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private GameObject _focalPoint;
    [SerializeField] private GameObject _playerAvatar;

    private Dictionary<Type, ICharacterBehaviour> _characterBehavioursMap;
    private ICharacterBehaviour _currentCharacterBehaviour;
    private CharacterController _characterController;
    private Animator _characterAnimator;
    private Vector3 _moveDirection;
    private float _velocity;
    private float _gravity = -18.81f;
    private float _jumpForce = 1.5f;
    private float _rotateDirection;
    private float _checkGroundRadius = 0.5f;
    private bool _isGrounded;
    private float _horizontal;
    private float _vertical;
    
    

    public float speed = 5f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _characterAnimator = gameObject.GetComponentInChildren<Animator>();
        this.InitBehaviours();
        this.SetBehaviourByDefault();
    }
   
    private void FixedUpdate()
    {
        _isGrounded = IsOnGround();

        if (_isGrounded && _velocity < 0)
        {
            _velocity = -2;
        }
        
        Move();
        DoGravity();
        this.SetBehaviourFalling();

    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity = Mathf.Sqrt(_jumpForce * -2 * _gravity);
        }
           
    }
   
    public void Move(Vector3 direction,float horizontal,float vertical,bool mouseInput)
    {
        _moveDirection = direction;
        _horizontal = horizontal;
        _vertical = vertical;
    }

    public void GetYRotation(float yRotation)
    {
        _rotateDirection = yRotation;
    }

    private void Move()
    {
        _characterController.Move(_moveDirection * Time.fixedDeltaTime * speed);
        Rotate();
        
    }

    public void Transformation(GameObject gameObjectToRaplaceWith)
    {
        gameObjectToRaplaceWith.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
        gameObjectToRaplaceWith.SetActive(true);
    }


    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0, _rotateDirection, 0);
        if (_horizontal > 0 && _vertical > 0 || _horizontal < 0 && _vertical > 0)
        {
            _playerAvatar.transform.rotation = Quaternion.Lerp(_playerAvatar.transform.rotation, Quaternion.LookRotation(_moveDirection), Time.fixedDeltaTime * 5);
        }
        else
        {
            _playerAvatar.transform.rotation = Quaternion.Lerp(_playerAvatar.transform.rotation, transform.rotation, Time.fixedDeltaTime * 5);
        }
    }

    public bool IsOnGround()
    {
        bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius,_groundMask);
        return result;
    }

    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }

    public void Attack()
    {
        SetBehaviourAtack();
    }

    private void InitBehaviours()
    {
        this._characterBehavioursMap = new Dictionary<Type, ICharacterBehaviour>();

        this._characterBehavioursMap[typeof(CharacterBehaviourIdle)] = new CharacterBehaviourIdle(_characterAnimator);
        this._characterBehavioursMap[typeof(CharacterBehaviourMoving)] = new CharacterBehaviourMoving(_characterAnimator);
        this._characterBehavioursMap[typeof(CharacterBehaviourJumping)] = new CharacterBehaviourJumping(_characterAnimator);
        this._characterBehavioursMap[typeof(CharacterBehaviourRuning)] = new CharacterBehaviourRuning(_characterAnimator);
        this._characterBehavioursMap[typeof(CharacterBehaviourFalling)] = new CharacterBehaviourFalling(_characterAnimator);
        this._characterBehavioursMap[typeof(CharacterBehaviourAtack)] = new CharacterBehaviourAtack(_characterAnimator);
    }

    private void SetBehaviour(ICharacterBehaviour newCharacterBehaviour)
    {
        if (this._currentCharacterBehaviour != null)
            this._currentCharacterBehaviour.Exit();

        this._currentCharacterBehaviour = newCharacterBehaviour;
        this._currentCharacterBehaviour.Enter();
    }

    private ICharacterBehaviour GetBehaviour<T>() where T : ICharacterBehaviour
    {
        var type = typeof(T);
        return this._characterBehavioursMap[type];
    }

    private void SetBehaviourByDefault()
    {
        this.SetBehaviourIdle();
    }

    public void SetBehaviourIdle()
    {
        var behaviour = this.GetBehaviour<CharacterBehaviourIdle>();
        this.SetBehaviour(behaviour);
    }

    public void SetBehaviourMoving()
    {
        var behaviour = this.GetBehaviour<CharacterBehaviourMoving>();
        this.SetBehaviour(behaviour);
    }

    public void SetBehaviourJumping()
    {
        var behaviour = this.GetBehaviour<CharacterBehaviourJumping>();
        this.SetBehaviour(behaviour);
    }

    public void SetBehaviourFalling()
    {
        _characterAnimator.SetBool("IsFalling", !_isGrounded);
    }

    public void SetBehaviourRuning()
    {
        var behaviour = this.GetBehaviour<CharacterBehaviourRuning>();
        this.SetBehaviour(behaviour);
    }
    public void SetBehaviourAtack()
    {
        var behaviour = this.GetBehaviour<CharacterBehaviourAtack>();
        this.SetBehaviour(behaviour);
    }
}
