using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourFalling : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourFalling(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {
        _characterAnimator.SetBool("IsFalling", true);
        
    }

    public void Exit()
    {
        _characterAnimator.SetBool("IsFalling", false);

    }
}
