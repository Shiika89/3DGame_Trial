using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーが部屋に入ったら敵を出すクラス
/// </summary>
public class EnemySpown : MonoBehaviour
{
    [SerializeField] GameObject m_enemy; // ここに出したい敵を入れる
    [SerializeField] GameObject[] m_spownPos; // 出したい数だけポジションを入れる

    bool m_spownFlag; // 一度だけ出すためのフラグ

    /// <summary>
    /// プレイヤーが入ったら配列の分だけ敵を生成
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!m_spownFlag)
        {
            Debug.Log("敵が現れた");
            foreach (var item in m_spownPos)
            {
                Instantiate(m_enemy, item.transform);
            }
            m_spownFlag = true;
        }
        
    }
}
