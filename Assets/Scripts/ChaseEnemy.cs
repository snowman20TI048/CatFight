using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //���ꂪ�K�v

public class ChaseEnemy : MonoBehaviour
{
    
    public GameObject target;  //���̃^�[�Q�b�g�͓��̂��Ƃł��B
    [SerializeField]
    private GameObject goalObject;
    private NavMeshAgent agent;
    private Animator animator;

    public enum ENEMY_STATE_TYPE
    {
        OWNER_CATCH,       //�G�����������Ă�����
        OPPONENT_CATCH,      //���������������Ă�����
        EMPTY,             //�N�����������Ă��Ȃ����
    }

    public ENEMY_STATE_TYPE enemy_state_type;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TryGetComponent(out animator);
        enemy_state_type = ENEMY_STATE_TYPE.EMPTY;
    }

    void Update()
    {
        if (enemy_state_type == ENEMY_STATE_TYPE.OWNER_CATCH)
        {
            // �S�[���I�u�W�F�N�g�̈ʒu��ړI�n�ɐݒ肷��B
            agent.destination = goalObject.transform.position;
            //������0�ɂȂ�������𗎂Ƃ��B
            if ((transform.position - goalObject.transform.position).sqrMagnitude < 1.0)
            {
                target.GetComponent<Radar>().Drop();
                enemy_state_type = ENEMY_STATE_TYPE.EMPTY;
            }
        }
        else if (enemy_state_type == ENEMY_STATE_TYPE.OPPONENT_CATCH)
        {

        }
        else if (enemy_state_type == ENEMY_STATE_TYPE.EMPTY)
        {

            if (target != null)
            {
                // �^�[�Q�b�g�̈ʒu��ړI�n�ɐݒ肷��B
                agent.destination = target.transform.position;

                //������0�ɂȂ�������𗎂Ƃ��B
                if ((transform.position - target.transform.position).sqrMagnitude < 1.0)
                {
                    target.GetComponent<Radar>().EnemyGet(gameObject);
                    enemy_state_type = ENEMY_STATE_TYPE.OWNER_CATCH;
                }
                


            }

        }

        //�ړ����Ă�����
        if (agent.velocity != Vector3.zero)
        {
            animator.SetFloat("Run", 0.3f);
        }
        else
        {
            animator.SetFloat("Run", 0);
        }

    }

}