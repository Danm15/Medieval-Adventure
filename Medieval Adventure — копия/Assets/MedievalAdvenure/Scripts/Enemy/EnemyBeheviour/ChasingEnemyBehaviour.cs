using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingEnemyBehaviour : StateMachineBehaviour
{
    
    private NavMeshAgent _navMeshAgent;
    private Transform _player;
    private float _atacRange = 2;
    private float _chasingDistance = 10;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponentInParent<NavMeshAgent>();
        if (GameObject.FindGameObjectWithTag("Player").activeSelf)
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        _navMeshAgent.stoppingDistance = 1;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(GameObject.FindGameObjectWithTag("Player").activeSelf)
        {
            animator.transform.LookAt(_player);
            _navMeshAgent.SetDestination(_player.position);
            float distance = Vector3.Distance(animator.transform.position, _player.position);
            if (distance <= _atacRange)
                animator.SetBool("IsAttacking", true);

            if (distance > _chasingDistance)
                animator.SetBool("IsChasing", false);

            
        }
        else
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsAttacking", false);
            animator.SetBool("IsChasing", false);
        }


    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.SetDestination(_navMeshAgent.transform.position);
    }

}
