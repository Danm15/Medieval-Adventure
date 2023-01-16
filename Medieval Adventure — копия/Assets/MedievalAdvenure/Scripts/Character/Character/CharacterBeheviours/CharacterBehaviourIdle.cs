using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourIdle : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourIdle(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {
        _characterAnimator.SetBool("IsMoving", false);
        _characterAnimator.SetBool("IsRuning", false);
        _characterAnimator.SetBool("IsFalling", false);
    }

    public void Exit()
    {
      
    }
}
