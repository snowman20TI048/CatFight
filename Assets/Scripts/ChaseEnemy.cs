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

    private Radar radar;

    public enum ENEMY_STATE_TYPE
    {
        OWNER_CATCH,       //�G�����������Ă�����
        OPPONENT_CATCH,      //���������������Ă�����
        EMPTY,             //�N�����������Ă��Ȃ����
        STOP,
    }

    public ENEMY_STATE_TYPE enemy_state_type;
    [SerializeField]
    private HitController hitControllerPrefab;

    [SerializeField]
    private Transform hitSpherePosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TryGetComponent(out animator);
        //enemy_state_type = ENEMY_STATE_TYPE.EMPTY;
        PrepareChangeState(ENEMY_STATE_TYPE.EMPTY);
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
                if ((transform.position - target.transform.position).sqrMagnitude < 1.0 )
                {
                    if (radar.ball_state_type == Radar.BALL_STATE_TYPE.EMPTY) 
                    {
                        //target.GetComponent<Radar>().EnemyGet(gameObject);
                        radar.EnemyGet(gameObject);


                        //enemy_state_type = ENEMY_STATE_TYPE.OWNER_CATCH;
                        PrepareChangeState(ENEMY_STATE_TYPE.OWNER_CATCH);
                    }

                    else if (radar.ball_state_type == Radar.BALL_STATE_TYPE.PLAYER_CATCH) 
                    {
                        animator.SetTrigger(AnimParameterType.Hit.ToString());
                        enemy_state_type = ENEMY_STATE_TYPE.STOP;
                    }

                }
            }
        }
        else if (enemy_state_type == ENEMY_STATE_TYPE.STOP)
        {
            // NavMeshAgent �ɂ��ړ���~
            agent.ResetPath();
            agent.velocity = Vector3.zero;
        }

        //�ړ����Ă�����
        if (agent.velocity != Vector3.zero)
        {
            // animator.SetFloat("Run", 0.3f);
            animator.SetFloat(AnimParameterType.Run.ToString(), 0.3f);
        }
        else
        {
            //animator.SetFloat("Run", 0);
            animator.SetFloat(AnimParameterType.Run.ToString(), 0);
        }

    }

    /// <summary>
    /// �X�e�[�g�̕ύX�̏���
    /// �O���N���X����͂���������s���ē����ŃR���[�`�����\�b�h�����s����
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="waitTime"></param>
    public void PrepareChangeState(ENEMY_STATE_TYPE nextState, float waitTime = 0f)
    {
        StartCoroutine(ChangeState(nextState, waitTime));
        //Debug.Log(nextState);
    }
    /// <summary>
    /// �X�e�[�g�̕ύX
    /// �R���[�`�����\�b�h�͊O�����璼�ڎ��s�����Ȃ�
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator ChangeState(ENEMY_STATE_TYPE nextState, float waitTime)
    {
        enemy_state_type = nextState;
        yield return new WaitForSeconds(waitTime);
        if (enemy_state_type == ENEMY_STATE_TYPE.STOP)
        {
            enemy_state_type = ENEMY_STATE_TYPE.EMPTY;
        }
    }
    /// <summary>
    /// ���̏����Z�b�g
    /// </summary>
    /// <param name="drumstick"></param>
    public void SetTarget(GameObject drumstick)
    {
        target = drumstick;
        target.TryGetComponent(out radar);
    }
    /// <summary>
    /// AnimationEvent �����s
    /// </summary>
    public void Hit()
    {
        Debug.Log("Hit�֐��̌Ăяo��");
        //animator.SetTrigger("Hit");

        // �����Ȃ������蔻��𐶂ݏo��
        HitController hitController = Instantiate(hitControllerPrefab, hitSpherePosition.position, Quaternion.identity);
        Destroy(hitController.gameObject, 0.5f);

        StartCoroutine(AttackInterval());
    }

    private IEnumerator AttackInterval() 
    {
        yield return new WaitForSeconds(1.0f);
        enemy_state_type = ENEMY_STATE_TYPE.EMPTY;
    }
}