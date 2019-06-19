using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    // ステージを走り続けるためのスクリプト
    const int StageTipSize = 30;
    int currentTipIndex;

    [SerializeField] Transform character;       // キャラクターの指定(今回の場合はネジ子)
    [SerializeField] GameObject[] stageTips;    // ステージチップのプレハブの配列
    [SerializeField] int startTipIndex;         // 自動生成開始のインデックス
    [SerializeField] int preInstantiate;        // 生成を先読みする個数
    [SerializeField] List<GameObject> generatedStageList = new List<GameObject>();  // 生成済みのチップを保持する

    // Start is called before the first frame update
    void Start()
    {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターの位置からステージチップのインデックスを計算
        int charaPosIndex = (int)(character.position.z / StageTipSize);

        // ステージを進むと更新処理
        if(charaPosIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPosIndex + preInstantiate);
        }
    }

    // 指定の箇所までステージチップを生成して管理
    void UpdateStage(int toTipIndex)
    {
        if(toTipIndex <= currentTipIndex)
        {
            return;
        }

        for(int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            // ステージをリストに追加
            generatedStageList.Add(stageObject);
        }

        // 古いステージの削除
        while (generatedStageList.Count > preInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentTipIndex = toTipIndex;
    }

    // 指定の位置にStageオブジェクトを生成
    private GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip], 
            new Vector3(0, 0, tipIndex * StageTipSize), 
            Quaternion.identity);
        return stageObject;
    }

    // 最も古いステージの削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
