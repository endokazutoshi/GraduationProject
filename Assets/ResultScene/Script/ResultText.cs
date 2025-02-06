using UnityEngine;

public class ResultText : MonoBehaviour
{
    public GameObject WinText1P;
    public GameObject LoseText1P;
    public GameObject WinText2P;
    public GameObject LoseText2P;
    public PlayerAnimationController playerAnimationController;  // PlayerAnimationController への参照

    void Start()
    {
        // 最初に全て非表示に設定
        WinText1P.SetActive(false);
        LoseText1P.SetActive(false);
        WinText2P.SetActive(false);
        LoseText2P.SetActive(false);

        // PlayerPrefs からゴール数を読み込む
        int player1Goal = PlayerPrefs.GetInt("Player1Goal", 0);  // デフォルト値は0
        int player2Goal = PlayerPrefs.GetInt("Player2Goal", 0);  // デフォルト値は0

        // ゴール数をデバッグで確認
        Debug.Log("Player1 Goal: " + player1Goal);
        Debug.Log("Player2 Goal: " + player2Goal);

        // プレイヤー1がゴールした場合
        if (player1Goal == 1 && player2Goal == 0)
        {
            WinText1P.SetActive(true);  // プレイヤー1の勝利
            LoseText2P.SetActive(true); // プレイヤー2の敗北
            // PlayerAnimationController にゴールの情報を渡してアニメーションを設定
            playerAnimationController.SetPlayerGoal(player1Goal, player2Goal);
        }
        // プレイヤー2がゴールした場合
        else if (player2Goal == 1 && player1Goal == 0)
        {
            WinText2P.SetActive(true);  // プレイヤー2の勝利
            LoseText1P.SetActive(true); // プレイヤー1の敗北
            // PlayerAnimationController にゴールの情報を渡してアニメーションを設定
            playerAnimationController.SetPlayerGoal(player1Goal, player2Goal);
        }
        // 両方がゴールした場合（不正な状態）
        else
        {
            Debug.LogWarning("不正なゴール状態です。両方のプレイヤーがゴールしている可能性があります。");
        }
    }
}
