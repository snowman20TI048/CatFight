using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    [SerializeField]
    private float knockbackPower = 5.0f;
    
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("HitTrigger");
        //Debug.Log(other.transform.GetChild(1).name);
        //Debug.Log(other.transform.GetChild(2).name);
        // if (!other.gameObject.CompareTag("Enemy"))
        // {
        //     return;
        // }
        // ?
        //Debug.Log(other.gameObject.name);?
        if (other.TryGetComponent(out ChaseEnemy enemy) == true)
        {
            //Debug.Log(other.gameObject.name);?
            if (enemy.enemy_state_type != ChaseEnemy.ENEMY_STATE_TYPE.OWNER_CATCH)
            {
                return;
            }
            
            if (other.transform.GetChild(2).TryGetComponent(out Radar radar) == true)
            {
                //radar.ball_state_type = Radar.BALL_STATE_TYPE.EMPTY;
                //radar.transform.SetParent(null);
                //?
                // �����h���b�v
                radar.Drop();
                //Debug.Log("�����Ƃ������I");
                //?
                // �G�Ɠ����m�b�N�o�b�N
                Knockback(enemy, radar);
                
                // �G�̃X�e�[�g�ύX�B���킹�Ĉړ���~������
                enemy.PrepareChangeState(ChaseEnemy.ENEMY_STATE_TYPE.STOP, 2.0f);
            }
        }
    }
    
    /// <summary>
    /// �m�b�N�o�b�N
    /// �R���[�`���̕K�v�����Ȃ��Ȃ����̂Œʏ�̃��\�b�h�ɕύX
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="radar"></param>
    private void Knockback(ChaseEnemy enemy, Radar radar)
    {
        // �G�𐁂���΂�����(�ړ����Ă������Ε���)��ݒ�
        Vector3 direction = (this.transform.position - enemy.transform.position).normalized;

        // �G�𐁂���΂�
        enemy.transform.position += direction * knockbackPower;

        // ���������_���ɐ�����΂�
        radar.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3f, 3f), 2f, Random.Range(-3f, 3f)) * 1000);
    }
}













