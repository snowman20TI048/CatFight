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

    public int PlayerPointCount;
    public int EnemyPointCount;


    // Start is called before the first frame update
    void Start()
    {
        GenerateBall();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
