using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンが読み込まれると設定したマップを自動でランダムに生成するためのクラス
/// </summary>
public class RandomStage : MonoBehaviour
{
    public static RandomStage Instance;

    [SerializeField] StageData[] stageDatas;
    [SerializeField] GameObject[] m_floorPrefab; // 作ったfloorを入れるための配列
    [SerializeField] float m_floorSize = 20; // floorの大きさ
    [SerializeField] GameObject[] m_gimmicks; // 作ったギミックを入れるための配列
    [SerializeField] int[] m_gimmickNum; // どのギミックを何個生成するかを決める変数
    [SerializeField] GameObject m_goal; // ゴールに置くギミック用の変数
    [SerializeField] GameObject m_bossFloor; // ボスのFloor

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (Gamemanager.Instance.Stage % 5 == 0)
        {
            Instantiate(m_bossFloor).transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            // StageDataで作った中からランダムで選んで生成
            int r = Random.Range(0, stageDatas.Length);
            StageCreate(stageDatas[r]);
        }
    }

    /// <summary>
    /// ギミックをランダムに配置するための関数
    /// </summary>
    /// <param name="stageData"></param>
    /// <returns></returns>
    GameObject[] RandamSet(StageData stageData)
    {
        int count = 0;
        // ギミックを置ける大きさをスタートとゴールを除いた大きさに設定
        GameObject[] gimmicks = new GameObject[stageData.StageSize * stageData.StageSize - 2];

        for (int i = 0; i < m_gimmicks.Length; i++)
        {
            for (int a = 0; a < m_gimmickNum[i]; a++)
            {
                // ここで設定したギミックの種類と数を掛けてgimmicksに入れる
                gimmicks[count] = m_gimmicks[i];
                count++;
            }
        }

        // gimiicksの中身をランダムにする
        for (int i = 0; i < gimmicks.Length; i++)
        {
            int r = Random.Range(0, gimmicks.Length);
            var g = gimmicks[i];
            gimmicks[i] = gimmicks[r];
            gimmicks[r] = g;
        }
        return gimmicks;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stageData"></param>
    void StageCreate(StageData stageData)
    {
        int count = 0;
        var gimmicks = RandamSet(stageData);

        for (int y = 0; y < stageData.StageSize; y++)
        {
            for (int x = 0; x < stageData.StageSize; x++)
            {
                var floor = Instantiate(m_floorPrefab[stageData.MapData[count].x]); // MapDataに入れたi番目のxに設定したfloorを生成
                floor.transform.position = new Vector3(x, 0, y) * m_floorSize; // positionをfloorの大きさ毎にずらす

                // RandamSetで設定したギミックを生成　スタートのfloorははじく
                if (count >= 1 && count <= gimmicks.Length)
                {
                    if (gimmicks[count - 1] != null)
                    {
                        Instantiate(gimmicks[count - 1],floor.transform).transform.position = floor.transform.position;
                    }
                }

                // 生成したfloorを設定した数だけ９０度回す
                floor.transform.rotation = Quaternion.Euler(0, stageData.MapData[count].y * 90, 0);
                floor.transform.SetParent(this.transform);
                count++;

                // ゴールのギミックだけは別で生成
                if (count == stageData.StageSize * stageData.StageSize)
                {
                    Instantiate(m_goal, floor.transform).transform.position = floor.transform.position;
                }
            }
        }
    }

    public void StageClear()
    {
        foreach (Transform child in gameObject.transform)
        {
            //削除する
            Destroy(child.gameObject);
        }
    }

    public void NextStage()
    {
        if (Gamemanager.Instance.Stage % 5 == 0)
        {
            Instantiate(m_bossFloor).transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            // StageDataで作った中からランダムで選んで生成
            int r = Random.Range(0, stageDatas.Length);
            StageCreate(stageDatas[r]);
        }
    }
}
