using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifeTime = 8f; // オブジェクトが消えるまでの時間
    public float textAppearTime = 4f; // テキストを表示し始める時間
    public GameObject[] countdownObjects; // 秒数ごとに表示するオブジェクト配列

    void Start()
    {
        // 最初はすべてのオブジェクトを非表示にする
        foreach (GameObject obj in countdownObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(ManageObjectLifecycle());
    }

    IEnumerator ManageObjectLifecycle()
    {
        yield return new WaitForSeconds(textAppearTime); // 指定時間待機

        // 秒数ごとにオブジェクトを表示
        for (int i = 0; i < countdownObjects.Length; i++)
        {
            countdownObjects[i].SetActive(true); // 対象のオブジェクトを表示
            yield return new WaitForSeconds(1f); // 1秒待つ
            countdownObjects[i].SetActive(false); // 1秒後に非表示にする
        }

        yield return new WaitForSeconds(lifeTime - textAppearTime - countdownObjects.Length); // 残りの時間待機
        Destroy(gameObject); // オブジェクトを削除
    }
}
