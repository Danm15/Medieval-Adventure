using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputContoller : MonoBehaviour
{
    [SerializeField] private CameraFollower _camera;
    [SerializeField] private GameObject[] _characters;
    private IControllable _player;
    private float _mouseSensetive = 500f;
    private bool _transformIsEnable = true;
    private float _taps = 0f;
    private float _speed;

    


    private void Awake()
    {
        _player = _characters[0].GetComponent<IControllable>();

        if(_player == null)
        {
            throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
        }
    }

    private void Update()
    {
        if (!PlayerHealthPoints.GameOver)
        {
            _speed = _characters[0].GetComponent<Character>().speed;
            ReadTransformationInput();
            ReadMoveInput();
            ReadJumpInput();
            ReadCameraInput();
            ReadDoubleTapInput();
            ReadAtackInput();


        }


    }

    private void ReadMoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool mouseInput = Input.GetKey(KeyCode.Mouse0);
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection =_characters[0].transform.TransformDirection(moveDirection);
        _player.Move(moveDirection,horizontal,vertical,mouseInput);

        if (horizontal == 0 && vertical == 0)
        {
            _characters[0].GetComponent<Character>().SetBehaviourIdle();
        }
        else if (_speed > 6)
        {
            _characters[0].GetComponent<Character>().SetBehaviourRuning();
        }
        else
        {
            _characters[0].GetComponent<Character>().SetBehaviourMoving();
        }

    }

    private void ReadJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Jump();
            _characters[0].GetComponent<Character>().SetBehaviourJumping();
        }
    }

    private void ReadDoubleTapInput()
    {
       
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
        {
            _taps++;
            if(_taps >= 2)
            {
                _characters[0].GetComponent<Character>().speed = 7;
                _taps = 0f;
            }
            StartCoroutine(DoubleTapInputTime());
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
        {
            
            if (_taps == 0)
            {
                _characters[0].GetComponent<Character>().speed = 5;
              
            }
        }

    }

    private void ReadCameraInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float mouseX = Input.GetAxis("Mouse X") * (-1) * _mouseSensetive * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensetive * Time.fixedDeltaTime;
            _camera.CameraMove(mouseX, mouseY);
        }
    }

    

    private void ReadTransformationInput()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && _transformIsEnable)
        {
            
            if (_player == _characters[0].GetComponent<IControllable>())
            {
                
                _player.Transformation(_characters[1]);
                _player = _characters[1].GetComponent<IControllable>();
                _camera.GetNewTarget(_characters[1].transform);
            }
            else if (_player == _characters[1].GetComponent<IControllable>())
            {
                
                _player.Transformation(_characters[0]);
                if (_characters[0].activeSelf)
                {
                    _player = _characters[0].GetComponent<IControllable>();
                    _camera.GetNewTarget(_characters[0].transform);
                }
               
            }
            StartCoroutine(TransformationReload());
        }
       

    }

    private void ReadAtackInput()
    {
        if (Input.GetKey(KeyCode.Mouse1) && _player == _characters[0].GetComponent<IControllable>())
        {
            _characters[0].GetComponent<Character>().speed = 0;
            _player.Attack();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _characters[0].GetComponent<Character>().speed = 5;
        }
    }


    private IEnumerator TransformationReload()
    {
        _transformIsEnable = false;
        yield return new WaitForSecondsRealtime(1);
        _transformIsEnable = true;

    }

    private IEnumerator DoubleTapInputTime()
    {
        if(_taps == 1)
        yield return new WaitForSecondsRealtime(0.2f);
        _taps = 0;

    }
}
