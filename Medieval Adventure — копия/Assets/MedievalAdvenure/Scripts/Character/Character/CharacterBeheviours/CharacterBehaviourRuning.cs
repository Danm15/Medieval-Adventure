using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourRuning : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourRuning(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {
        _characterAnimator.SetBool("IsRuning", true);
        _characterAnimator.SetBool("IsMoving", true);

    }

    public void Exit()
    {
        _characterAnimator.SetBool("IsRuning", false);
        _characterAnimator.SetBool("IsMoving", false);

    }
}
