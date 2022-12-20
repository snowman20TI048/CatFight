
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

   

   
    [SerializeField, Header("Linecast用 味方陣地判定レイヤー")]
    private LayerMask playerArea;
    [SerializeField, Header("Linecast用 敵陣地判定レイヤー")]
    private LayerMask enemyArea;

    public bool isPlayerArea = false;
    public bool isEnemyArea = false;


    public Radar radarScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isPlayerArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, playerArea);
        isEnemyArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, enemyArea);

        if (isPlayerArea == true && radarScript.isChild == false)
        {
            gameManager.AddEnemyPointCount();
            Destroy(this.gameObject);
        }

        if (isEnemyArea == true && radarScript.isChild == false)
        {
            gameManager.AddPlayerPointCount();           
            Destroy(this.gameObject);
        }
    }

    public void SetUpBall(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
}
