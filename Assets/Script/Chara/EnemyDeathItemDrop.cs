using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyの死亡プレハブにつけるクラス
/// 宝玉をランダムに落とす
/// </summary>
public class EnemyDeathItemDrop : MonoBehaviour
{
    [SerializeField] GameObject[] m_dropItem; // ここに落とす宝玉を入れる
    [SerializeField] float m_dropTime; // 宝玉が落ちるまでの時間
    [SerializeField] float m_destroyTime; // 自分が消えるまでの時間

    // Start is called before the first frame update
    void Start()
    {
        // アイテムを出して自分を消す
        StartCoroutine("ItemDrop");
        Destroy(this.gameObject, m_destroyTime);
    }

    IEnumerator ItemDrop()
    {
        yield return new WaitForSeconds(m_dropTime);

        // 登録した宝玉をランダムに生成
        var number = Random.Range(0, m_dropItem.Length);
        Instantiate(m_dropItem[number], new Vector3(transform.position.x, 0.32f, transform.position.z), transform.rotation);
    }
}
