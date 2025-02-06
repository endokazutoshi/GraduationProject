using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // PlayerGoalに応じてアニメーションを設定
    public void SetPlayerGoal(int player1Goal, int player2Goal)
    {
        // プレイヤー1がゴールした場合
        if (player1Goal == 1 && player2Goal == 0)
        {
            // プレイヤー1に勝利アニメーションを設定
            if (CompareTag("Player1"))
            {
                animator.SetBool("lose", true);
                Debug.Log("Player1 wins!");
            }
        }
        // プレイヤー2がゴールした場合
        else if (player2Goal == 1 && player1Goal == 0)
        {
            // プレイヤー2に勝利アニメーションを設定
            if (CompareTag("Player2"))
            {
                animator.SetBool("win", true);
                Debug.Log("Player2 wins!");
            }
        }
    }
}
