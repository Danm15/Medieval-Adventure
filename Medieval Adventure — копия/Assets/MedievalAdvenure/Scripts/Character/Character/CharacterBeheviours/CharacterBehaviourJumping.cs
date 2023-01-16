using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourJumping : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourJumping(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {
        _characterAnimator.SetTrigger("JumpTrigger");
    }

    public void Exit()
    {
       
    }
}
