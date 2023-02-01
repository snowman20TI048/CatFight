using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleControllers : MonoBehaviour
{
    [SerializeField]
    private Button btnTitle;

    [SerializeField]
    private Text lblStart;

    [SerializeField]
    private CanvasGroup canvasGroupTitle;

    private Tweener tweener;
    ////* 新しくメソッドを４つ追加。ここから *////

    private void Start()
    {

        // タイトル表示
        SwitchDisplayTitle(true, 1.0f);

        // ボタンのOnClickイベントにメソッドを登録
        btnTitle.onClick.AddListener(OnClickTitle);
    }

    /// <summary>
    /// タイトル表示（処理をコメントで書いてみましょう）
    /// </summary>
    public void SwitchDisplayTitle(bool isSwitch, float alpha)
    {
        if (isSwitch) canvasGroupTitle.alpha = 0;

        canvasGroupTitle.DOFade(alpha, 1.0f).SetEase(Ease.Linear).OnComplete(() => {
            lblStart.gameObject.SetActive(isSwitch);
        });

        if (tweener == null)
        {
            // Tap Startの文字をゆっくり点滅させる
            tweener = lblStart.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            tweener.Kill();
        }
    }

    /// <summary>
    /// タイトル表示中に画面をクリックした際の処理
    /// </summary>
    private void OnClickTitle()
    {
        // ボタンのメソッドを削除して重複タップ防止
        btnTitle.onClick.RemoveAllListeners();

        // タイトルを徐々に非表示
        SwitchDisplayTitle(false, 0.0f);

        // タイトル表示が消えるのと入れ替わりで、ゲームスタートの文字を表示する
        StartCoroutine(DisplayGameStartInfo());
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public IEnumerator DisplayGameStartInfo()
    {
        yield return new WaitForSeconds(0.5f);


        yield return new WaitForSeconds(1.0f);
      
        canvasGroupTitle.gameObject.SetActive(false);

        SceneManager.LoadScene("Main");
    }

    ////* ここまで *////
}
