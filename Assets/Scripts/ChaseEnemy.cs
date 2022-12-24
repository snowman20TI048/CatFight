using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //���ꂪ�K�v

public class ChaseEnemy : MonoBehaviour
{
    
    public GameObject target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // �^�[�Q�b�g�̈ʒu��ړI�n�ɐݒ肷��B
            agent.destination = target.transform.position;
        }
    }
}