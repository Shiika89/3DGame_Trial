using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStage : MonoBehaviour
{
    [SerializeField] StageData[] stageDatas;
    [SerializeField] GameObject[] m_stagePrefab;
    [SerializeField] float m_prefabSize = 20;
    [SerializeField] GameObject[] m_gimmicks;
    [SerializeField] int[] m_gimmickNum;
    [SerializeField] GameObject m_goal;

    void Start()
    {
        int r = Random.Range(0, stageDatas.Length);
        StageCreate(stageDatas[r]);
    }
    GameObject[] RandamSet(StageData stageData)
    {
        int count = 0;
        GameObject[] gimmicks = new GameObject[stageData.StageSize * stageData.StageSize - 2];
        for (int i = 0; i < m_gimmicks.Length; i++)
        {
            for (int a = 0; a < m_gimmickNum[i]; a++)
            {
                gimmicks[count] = m_gimmicks[i];
                count++;
            }
        }
        for (int i = 0; i < gimmicks.Length; i++)
        {
            int r = Random.Range(0, gimmicks.Length);
            var g = gimmicks[i];
            gimmicks[i] = gimmicks[r];
            gimmicks[r] = g;
        }
        return gimmicks;
    }


    void StageCreate(StageData stageData)
    {
        int count = 0;
        var gimmicks = RandamSet(stageData);
        for (int y = 0; y < stageData.StageSize; y++)
        {
            for (int x = 0; x < stageData.StageSize; x++)
            {
                var floor = Instantiate(m_stagePrefab[stageData.MapData[count].x]);
                floor.transform.position = new Vector3(x, 0, y) * m_prefabSize;
                if (count >= 1 && count <= gimmicks.Length)
                {
                    if (gimmicks[count - 1] != null)
                    {
                        Instantiate(gimmicks[count - 1],floor.transform).transform.position = floor.transform.position;
                    }
                }
                floor.transform.rotation = Quaternion.Euler(0, stageData.MapData[count].y * 90, 0);
                floor.transform.SetParent(this.transform);
                count++;
                if (count == stageData.StageSize * stageData.StageSize)
                {
                    Instantiate(m_goal, floor.transform).transform.position = floor.transform.position;
                }
            }
        }
    }
}
