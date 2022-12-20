
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Text PointLabel;

    public int PointCount;

    [SerializeField, Header("Linecast用 地面判定レイヤー")]
    private LayerMask pointLayer;
    public bool isPointed = false;

    public Radar radarScript;

    // Start is called before the first frame update
    void Start()
    {
        PointLabel.text = "ポイント：" + PointCount;
    }

    // Update is called once per frame
    void Update()
    {
        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isPointed = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, pointLayer);

        if (isPointed == true && radarScript.isChild == false)
        {
            PointCount++;
            PointLabel.text = "ポイント：" + PointCount;
        }
    }
}
