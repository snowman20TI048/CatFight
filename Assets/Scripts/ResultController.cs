using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
