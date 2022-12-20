
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Text PointLabel;

    public int PlayerPointCount;
    public int EnemyPointCount;

    [SerializeField, Header("Linecast用 味方陣地判定レイヤー")]
    private LayerMask playerArea;
    [SerializeField, Header("Linecast用 敵陣地判定レイヤー")]
    private LayerMask enemyArea;

    public bool isPlayerArea = false;
    public bool isEnemyArea = false;


    public Radar radarScript;

    // Start is called before the first frame update
    void Start()
    {
        PointLabel.text = "自分のポイント：" + PlayerPointCount
            + "\n相手のポイント：" + EnemyPointCount;
    }

    // Update is called once per frame
    void Update()
    {
        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isPlayerArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, playerArea);
        isEnemyArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, enemyArea);

        if (isPlayerArea == true && radarScript.isChild == false)
        {
            PlayerPointCount++;
            PointLabel.text = "自分のポイント：" + PlayerPointCount
             + "\n相手のポイント：" + EnemyPointCount;
        }

        if (isEnemyArea == true && radarScript.isChild == false)
        {
            EnemyPointCount++;
            PointLabel.text = "自分のポイント：" + PlayerPointCount
             + "\n相手のポイント：" + EnemyPointCount;
        }
    }
}
