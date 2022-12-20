
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Text PointLabel;

    public int PointCount;

    // Start is called before the first frame update
    void Start()
    {
        PointLabel.text = "ポイント：" + PointCount;
    }

    // Update is called once per frame
    void Update()
    {
        PointLabel.text = "ポイント：" + PointCount;
    }
}
