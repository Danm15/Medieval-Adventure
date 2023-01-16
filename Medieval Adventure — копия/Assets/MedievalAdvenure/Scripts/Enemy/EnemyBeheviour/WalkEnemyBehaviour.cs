using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkEnemyBehaviour : StateMachineBehaviour
{
    private float _isWalkingTimer;
    private List<Transform> _navPointsMap = new List<Transform>();
    private NavMeshAgent _navMeshAgent;
    private Transform _player;
    private float _chasingDistance = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isWalkingTimer = 0;
        if (GameObject.FindGameObjectWithTag("Player").activeSelf)
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform transform in pointsObject)
            _navPointsMap.Add(transform);
        _navMeshAgent = animator.GetComponentInParent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_navPointsMap[0].position);
        _navMeshAgent.stoppingDistance = 1;

    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(animator.transform);
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _navMeshAgent.SetDestination(_navPointsMap[Random.Range(0, _navPointsMap.Count)].position);
        }

        _isWalkingTimer += Time.deltaTime;
        if (_isWalkingTimer > 20)
        {
            animator.SetBool("IsWalking", false);
        }
        float distance = Vector3.Distance(animator.transform.position, _player.position);

        if (distance <= _chasingDistance)
            animator.SetBool("IsChasing", true);
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent.SetDestination(_navMeshAgent.transform.position);
    }

  
}
