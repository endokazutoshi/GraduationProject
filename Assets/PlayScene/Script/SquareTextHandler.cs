using UnityEngine;
using UnityEngine.UI;

public class SquareTextHandler : MonoBehaviour
{
    // プレイヤーごとのテキスト
    public Text player1Text;
    public Text player2Text;

    // テキストの親キャンバス（ディスプレイ制御用）
    public Canvas player1Canvas;
    public Canvas player2Canvas;

    // プレイヤーのタグ
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";

    // 表示させるディスプレイ番号
    public int player1Display = 1; // Player1用ディスプレイ
    public int player2Display = 2; // Player2用ディスプレイ

    private void Start()
    {
        // 最初はテキストを非表示にする
        if (player1Text != null) player1Text.gameObject.SetActive(false);
        if (player2Text != null) player2Text.gameObject.SetActive(false);

        // 各キャンバスのターゲットディスプレイを設定
        if (player1Canvas != null) player1Canvas.targetDisplay = player1Display - 1;
        if (player2Canvas != null) player2Canvas.targetDisplay = player2Display - 1;

        // 利用可能なディスプレイを有効化
        if (Display.displays.Length > 1) Display.displays[1].Activate();
        if (Display.displays.Length > 2) Display.displays[2].Activate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player1がSquareに入った場合
        if (other.CompareTag(player1Tag))
        {
            if (player1Text != null) player1Text.gameObject.SetActive(true);
        }

        // Player2がSquareに入った場合
        if (other.CompareTag(player2Tag))
        {
            if (player2Text != null) player2Text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player1がSquareから出た場合
        if (other.CompareTag(player1Tag))
        {
            if (player1Text != null) player1Text.gameObject.SetActive(false);
        }

        // Player2がSquareから出た場合
        if (other.CompareTag(player2Tag))
        {
            if (player2Text != null) player2Text.gameObject.SetActive(false);
        }
    }
}
