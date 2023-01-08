using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //これが必要

public class ChaseEnemy : MonoBehaviour
{
    
    public GameObject target;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TryGetComponent(out animator);
    }

    void Update()
    {
        if (target != null)
        {
            // ターゲットの位置を目的地に設定する。
            agent.destination = target.transform.position;

            /*
            if (agent.isStopped == false)
            {
                animator.SetFloat("Run", 0.3f);
            }
            else
            {
                animator.SetFloat("Run", 0);
            }
            */
        }

        
    }

}