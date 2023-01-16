using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviourAtack : ICharacterBehaviour
{
    private Animator _characterAnimator;

    public CharacterBehaviourAtack(Animator animator) => _characterAnimator = animator;

    public void Enter()
    {

        _characterAnimator.SetBool("IsAtacking", true);
    }

    public void Exit()
    {
        _characterAnimator.SetBool("IsAtacking", false);

    }
}
