using UnityEngine;

public class PlayerAnimationController2 : MonoBehaviour
{
    private Animator animator;

    private string winAnimation = "win";  // 勝利のブール変数名
    private string loseAnimation = "lose";  // 敗北のブール変数名

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // プレイヤーが勝った場合に呼ばれる
    public void SetWinAnimation(bool state)
    {
        if (animator != null)
        {
            animator.SetBool(winAnimation, state);  // 勝利アニメーションの状態を設定
        }
    }

    // プレイヤーが負けた場合に呼ばれる
    public void SetLoseAnimation(bool state)
    {
        if (animator != null)
        {
            animator.SetBool(loseAnimation, state);  // 敗北アニメーションの状態を設定
        }
    }
}
