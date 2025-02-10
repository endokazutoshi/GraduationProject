//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ResultText : MonoBehaviour
{
    public GameObject WinText1P;
    public GameObject LoseText1P;
    public GameObject WinText2P;
    public GameObject LoseText2P;

    public PlayerAnimationController1 player1AnimationController;  // プレイヤー1のアニメーション制御
    public PlayerAnimationController2 player2AnimationController;  // プレイヤー2のアニメーション制御
    public PlayerAnimationController1camera2 player1camera2AnimationController;
    public PlayerAnimationController2camera2 player2camera2AnimationContoroller;

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
            // アニメーション設定
            if (player1AnimationController != null)
            {
                player1AnimationController.SetWinAnimation(true);  // プレイヤー1の勝利アニメーション
            }
            if (player2AnimationController != null)
            {
                Debug.Log("Player2が負けたよ");
                player2AnimationController.SetLoseAnimation(true);  // プレイヤー2の敗北アニメーション
            }
            if (player1camera2AnimationController != null)
            {
                player1camera2AnimationController.SetWinAnimation(true);//プレイヤー１の勝利アニメーション
            }
            if (player2camera2AnimationContoroller != null)
            {
                player2camera2AnimationContoroller.SetLoseAnimation(true);//プレイヤー２の敗北アニメーション
            }

            // テキスト表示
            WinText1P.SetActive(true);  // プレイヤー1の勝利
            LoseText2P.SetActive(true); // プレイヤー2の敗北
        }
        // プレイヤー2がゴールした場合
        else if (player2Goal == 1 && player1Goal == 0)
        {
            // アニメーション設定
            if (player2AnimationController != null)
            {
                Debug.Log("Player2が勝ったよ");
                player2AnimationController.SetWinAnimation(true);  // プレイヤー2の勝利アニメーション
            }
            if (player1AnimationController != null)
            {
                player1AnimationController.SetLoseAnimation(true);  // プレイヤー1の敗北アニメーション
            }
            if (player1camera2AnimationController != null)
            {
                player1camera2AnimationController.SetLoseAnimation(true);//プレイヤー1の敗北アニメーション
            }
            if (player2camera2AnimationContoroller != null)
            {
                player2camera2AnimationContoroller.SetWinAnimation(true);//プレイヤー2の勝利アニメーション
            }
            // テキスト表示
            WinText2P.SetActive(true);  // プレイヤー2の勝利
            LoseText1P.SetActive(true); // プレイヤー1の敗北
        }
        // 両方がゴールした場合（不正な状態）
        else
        {
            Debug.LogWarning("不正なゴール状態です。両方のプレイヤーがゴールしている可能性があります。");
        }
    }
}
