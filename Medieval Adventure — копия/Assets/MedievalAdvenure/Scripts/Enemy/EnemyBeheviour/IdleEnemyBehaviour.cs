using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyBehaviour : StateMachineBehaviour
{
    private float _isStandingTimer;
    private Transform _player;
    private float _chasingDistance = 10;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isStandingTimer = 0;
        if (GameObject.FindGameObjectWithTag("Player").activeSelf)
            _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isStandingTimer += Time.deltaTime;
        if (_isStandingTimer > 3)
        {
            animator.SetBool("IsWalking", true);
        }

        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance <= _chasingDistance)
            animator.SetBool("IsChasing", true);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
   
}
