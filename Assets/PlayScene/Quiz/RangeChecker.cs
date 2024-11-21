using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    public Transform player1;           // プレイヤー1のTransform
    public Transform player2;           // プレイヤー2のTransform
    public Vector2 rangeCenter;         // 範囲の中心座標
    public Vector2 rangeSize = new Vector2(5f, 5f); // 範囲のサイズ
    public GameObject imageObject;      // 表示する画像オブジェクト

    private bool isImageVisible = false; // 画像が現在表示されているか

    void Start()
    {
        // 画像を非表示に設定
        if (imageObject != null)
        {
            imageObject.SetActive(false);
        }
    }

    void Update()
    {
        // プレイヤー1とプレイヤー2が範囲内にいるかを確認
        bool isPlayer1InRange = IsPlayerInRange(player1);
        bool isPlayer2InRange = IsPlayerInRange(player2);

        // プレイヤー1が範囲内にいてスペースキーを押した場合
        if (isPlayer1InRange && Input.GetButtonDown("B_Button_1P"))
        {
            ToggleImage();
        }

        // プレイヤー2が範囲内にいて「B」ボタン（カスタマイズ可能）を押した場合
        if (isPlayer2InRange && Input.GetButtonDown("B_Button_2P"))
        {
            ToggleImage();
        }
    }

    // 指定されたプレイヤーが範囲内にいるか判定する
    private bool IsPlayerInRange(Transform player)
    {
        if (player == null) return false;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y);

        // 範囲の左下と右上を計算
        Vector2 bottomLeft = rangeCenter - rangeSize / 2;
        Vector2 topRight = rangeCenter + rangeSize / 2;

        // プレイヤーの位置が範囲内か判定
        return playerPos.x >= bottomLeft.x && playerPos.x <= topRight.x &&
               playerPos.y >= bottomLeft.y && playerPos.y <= topRight.y;
    }

    // 画像の表示と非表示を切り替える
    private void ToggleImage()
    {
        if (imageObject != null)
        {
            isImageVisible = !isImageVisible; // 表示状態を切り替える
            imageObject.SetActive(isImageVisible);
        }
    }

    // 範囲をシーンビューで可視化する（デバッグ用）
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rangeCenter, rangeSize);
    }
}
