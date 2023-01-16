using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyBehaviour : StateMachineBehaviour
{
    
    private Transform _player;
    private float _atacRange = 2;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
       _player = GameObject.FindGameObjectWithTag("Player").transform;
     
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_player != null)
        {
            animator.transform.LookAt(_player);
            float distance = Vector3.Distance(animator.transform.position, _player.position);
            
            if (distance > _atacRange)
                animator.SetBool("IsAttacking", false);
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
