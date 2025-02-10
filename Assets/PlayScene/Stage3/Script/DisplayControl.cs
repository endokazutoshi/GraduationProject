using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    public GameObject item;  // 表示するアイテム

    void Start()
    {
        // ディスプレイ1が存在する場合、Display1にアイテムを表示
        if (Display.displays.Length > 1)
        {
            // Display1にアイテムを表示
            Display.displays[0].Activate(); // ディスプレイ1を有効化
            item.SetActive(true); // アイテムを表示
        }

        // Display2にアイテムを表示しない
        if (Display.displays.Length > 1)
        {
            // Display2にアイテムを表示しない
            Display.displays[1].Activate(); // ディスプレイ2を有効化
            item.SetActive(false); // アイテムを非表示
        }
    }
}
