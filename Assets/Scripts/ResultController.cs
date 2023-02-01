using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{

    [SerializeField]
    private Text lblPoint;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトを名前で探す
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        lblPoint.text = "自分のポイント：" +gameManager.PlayerPointCount
        + "\n相手のポイント：" + gameManager.EnemyPointCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 1.5秒後に「GoToResult()」メソッドを実行する。
            Invoke("GoToTitle", 1.5f);

        }
        
    }

// ★追加
void GoToTitle()
{
    SceneManager.LoadScene("Title");
}

}
