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
    ////* �V�������\�b�h���S�ǉ��B�������� *////

    private void Start()
    {

        // �^�C�g���\��
        SwitchDisplayTitle(true, 1.0f);

        // �{�^����OnClick�C�x���g�Ƀ��\�b�h��o�^
        btnTitle.onClick.AddListener(OnClickTitle);
    }

    /// <summary>
    /// �^�C�g���\���i�������R�����g�ŏ����Ă݂܂��傤�j
    /// </summary>
    public void SwitchDisplayTitle(bool isSwitch, float alpha)
    {
        if (isSwitch) canvasGroupTitle.alpha = 0;

        canvasGroupTitle.DOFade(alpha, 1.0f).SetEase(Ease.Linear).OnComplete(() => {
            lblStart.gameObject.SetActive(isSwitch);
        });

        if (tweener == null)
        {
            // Tap Start�̕������������_�ł�����
            tweener = lblStart.gameObject.GetComponent<CanvasGroup>().DOFade(0, 1.0f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            tweener.Kill();
        }
    }

    /// <summary>
    /// �^�C�g���\�����ɉ�ʂ��N���b�N�����ۂ̏���
    /// </summary>
    private void OnClickTitle()
    {
        // �{�^���̃��\�b�h���폜���ďd���^�b�v�h�~
        btnTitle.onClick.RemoveAllListeners();

        // �^�C�g�������X�ɔ�\��
        SwitchDisplayTitle(false, 0.0f);

        // �^�C�g���\����������̂Ɠ���ւ��ŁA�Q�[���X�^�[�g�̕�����\������
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

    ////* �����܂� *////
}
