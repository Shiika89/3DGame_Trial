using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 階段につけるスクリプト、階層が変わると呼ばれる
/// </summary>
public class NextStage : MonoBehaviour
{
    Animator m_stageTextAnim;

    private void Start()
    {
        m_stageTextAnim = GameObject.Find("StageText").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.Key) // 鍵を持ってたら
        {
            // 今あるステージを消して新しいステージを生成
            RandomStage.Instance.StageClear();
            RandomStage.Instance.NextStage();

            // プレイヤーを初期位置に
            PlayerStatus.Instance.gameObject.transform.position = Vector3.zero;

            GameManager.Instance.Stage++;
            GameManager.Instance.Key = false;
            GameManager.Instance.StageBGM();

            m_stageTextAnim.SetTrigger("NextStage");

            // 残った宝玉を削除
            ItemManager.Instance.DeleteJewel();

            
            
        }
    }
}
