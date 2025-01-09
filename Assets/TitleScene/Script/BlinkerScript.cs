using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkerScript : MonoBehaviour
{
    public float speed = 1.0f;
    private float time;
    private TextMeshProUGUI tmpText; // TMP 用の変数

    void Start()
    {
        // TextMeshProUGUI コンポーネントを取得
        tmpText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // テキストの透明度を更新
        tmpText.color = GetTextColorAlpha(tmpText.color);
    }

    Color GetTextColorAlpha(Color color)
    {
        time += Time.deltaTime * speed * 5.0f;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f; // 0.0 ～ 1.0 の範囲に収める

        return color;
    }
}
