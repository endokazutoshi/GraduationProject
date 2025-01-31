using UnityEngine;

public class ResultText : MonoBehaviour
{
    public GameObject WinText1P;
    public GameObject LoseText1P;

    public GameObject WinText2P;
    public GameObject LoseText2P;

    // Start is called before the first frame update
    void Start()
    {
        WinText1P.SetActive(false);
        LoseText2P.SetActive(false);
        WinText2P.SetActive(false);
        LoseText1P.SetActive(false);
        // PlayerPrefs からゴール数を読み込む
        int player1Goal = PlayerPrefs.GetInt("Player1Goal", 0);  // デフォルト値は0
        int player2Goal = PlayerPrefs.GetInt("Player2Goal", 0);  // デフォルト値は0

        // プレイヤー1がゴールした場合
        if (player1Goal == 1 && player2Goal == 0)
        {
            Debug.Log("playergoal1  "+ player1Goal);
            Debug.Log("playergoal2  " + player2Goal);
            WinText1P.SetActive(true);  // プレイヤー1の勝利
            LoseText2P.SetActive(true); // プレイヤー2の敗北
        }
        // プレイヤー2がゴールした場合
        else if (player2Goal == 1 && player1Goal == 0)
        {
            Debug.Log("playergoal1  " + player1Goal);
            Debug.Log("playergoal2  " + player2Goal);
            WinText2P.SetActive(true);  // プレイヤー2の勝利
            LoseText1P.SetActive(true); // プレイヤー1の敗北
        }
        // 両方がゴールした場合は表示しない（不正な状態）
        else
        {
            Debug.LogWarning("不正なゴール状態です。両方のプレイヤーがゴールしている可能性があります。");
        }
    }
}
