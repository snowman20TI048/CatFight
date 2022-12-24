using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject DrumstickPrefab;

    [SerializeField]
    private Text PointLabel;


    [SerializeField]
    private Text TimeLabel;

    public int PlayerPointCount;
    public int EnemyPointCount;

    [Header("制限時間")]
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        GenerateBall();
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    public void AddPlayerPointCount()
    {
        PlayerPointCount++;
        PointLabel.text = "自分のポイント：" + PlayerPointCount
         + "\n相手のポイント：" + EnemyPointCount;
        GenerateBall();
    }

    public void AddEnemyPointCount()
    {
        EnemyPointCount++;
        PointLabel.text = "自分のポイント：" + PlayerPointCount
         + "\n相手のポイント：" + EnemyPointCount;
        GenerateBall();
    }

    private void GenerateBall()
    {
       GameObject drumstick = Instantiate(DrumstickPrefab, new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity);
        drumstick.GetComponent<BallController>().SetUpBall(this);
    }

    private void CountDown()
    {
        //時間をカウントダウンする
        timer -= Time.deltaTime;

        //時間を表示する
        TimeLabel.text  = timer.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (timer <= 0)
        {
            TimeLabel.text = "0秒";
        }
    }
}
