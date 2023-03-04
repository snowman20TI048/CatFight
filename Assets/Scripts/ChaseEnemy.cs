using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //これが必要

public class ChaseEnemy : MonoBehaviour
{

    public GameObject target;  //このターゲットは肉のことです。
    [SerializeField]
    private GameObject goalObject;
    private NavMeshAgent agent;
    private Animator animator;

    private Radar radar;

    public enum ENEMY_STATE_TYPE
    {
        OWNER_CATCH,       //敵が肉を持っている状態
        OPPONENT_CATCH,      //自分が肉を持っている状態
        EMPTY,             //誰も肉を持っていない状態
        STOP,
    }

    public ENEMY_STATE_TYPE enemy_state_type;

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
            // ゴールオブジェクトの位置を目的地に設定する。
            agent.destination = goalObject.transform.position;
            //距離が0になったら肉を落とす。
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
                // ターゲットの位置を目的地に設定する。
                agent.destination = target.transform.position;

                //距離が0になったら肉を落とす。
                if ((transform.position - target.transform.position).sqrMagnitude < 1.0)
                {
                    //target.GetComponent<Radar>().EnemyGet(gameObject);
                    radar.EnemyGet(gameObject);

                    //enemy_state_type = ENEMY_STATE_TYPE.OWNER_CATCH;
                    PrepareChangeState(ENEMY_STATE_TYPE.OWNER_CATCH);
                }
            }
        }
        else if (enemy_state_type == ENEMY_STATE_TYPE.STOP)
        {
            // NavMeshAgent による移動停止
            agent.ResetPath();
            agent.velocity = Vector3.zero;
        }

        //移動していたら
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
    /// ステートの変更の準備
    /// 外部クラスからはこちらを実行して内部でコルーチンメソッドを実行する
    /// </summary>
    /// <param name="nextState"></param>
    /// <param name="waitTime"></param>
    public void PrepareChangeState(ENEMY_STATE_TYPE nextState, float waitTime = 0f)
    {
        StartCoroutine(ChangeState(nextState, waitTime));
        //Debug.Log(nextState);
    }
    /// <summary>
    /// ステートの変更
    /// コルーチンメソッドは外部から直接実行させない
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
    /// 肉の情報をセット
    /// </summary>
    /// <param name="drumstick"></param>
    public void SetTarget(GameObject drumstick)
    {
        target = drumstick;
        target.TryGetComponent(out radar);
    }
}