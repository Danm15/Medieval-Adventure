using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourMoving : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourMoving(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {
        _characterAnimator.SetBool("IsMoving", true);
        
    }

    public void Exit()
    {
        _characterAnimator.SetBool("IsMoving", false);
        
    }
}
