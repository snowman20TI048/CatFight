using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //���ꂪ�K�v

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
            // �^�[�Q�b�g�̈ʒu��ړI�n�ɐݒ肷��B
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