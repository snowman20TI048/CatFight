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
            Debug.Log(other.gameObject.name);

            // 敵をノックバック
            KnockbackEnemy(enemy);
            // 敵のステート変更。合わせて移動停止させる
            enemy.PrepareChangeState(ChaseEnemy.ENEMY_STATE_TYPE.STOP, 2.0f);

            //肉を持っていなかった場合エラーが表示されてしまったので、これを足しました。
            if (other.transform.childCount < 4)
            { 
                return;
            }

            //敵が肉を持っていたら
            if (other.transform.GetChild(3).TryGetComponent(out Radar radar) == true)
            {
                //radar.ball_state_type = Radar.BALL_STATE_TYPE.EMPTY;
                //radar.transform.SetParent(null);
                //?
                // 肉をドロップ
                radar.Drop();
                Debug.Log("肉落とし成功！");
                //?
                // 肉をノックバック
                KnockbackDrumStick(radar);

            }

        }
    }
    
    /// <summary>
    /// ノックバック
    /// コルーチンの必要性がなくなったので通常のメソッドに変更
    /// </summary>
    /// <param name="enemy"></param>
    /// <param name="radar"></param>
    private void KnockbackEnemy(ChaseEnemy enemy)
    {
        // 敵を吹き飛ばす方向(移動してきた反対方向)を設定
        Vector3 direction = (this.transform.position - enemy.transform.position).normalized;

        // 敵を吹き飛ばす
        enemy.transform.position += direction * knockbackPower;

        
    }

    private void KnockbackDrumStick(Radar radar)
    {
        // 肉をランダムに吹き飛ばす
        radar.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-3f, 3f), 2f, Random.Range(-3f, 3f)) * 1000);
    }

}













