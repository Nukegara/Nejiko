using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        // プレハブの設定
        GameObject go = (GameObject)Instantiate(
            prefab, Vector3.zero, Quaternion.identity);

        // 一緒に削除されるように敵オブジェクトを子にする
        go.transform.SetParent(transform, false);
    }

    void OnDrawGizmos()
    {
        // ギズモの底辺が地面と同じ高さになるようにオフセットを設定
        Vector3 offset = new Vector3(0, 0.5f, 0);
        // 球の表示
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);
        // プレハブ名のアイコンを表示
        if(prefab != null)
        {
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
