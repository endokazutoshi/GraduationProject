using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // PlayerGoal�ɉ����ăA�j���[�V������ݒ�
    public void SetPlayerGoal(int player1Goal, int player2Goal)
    {
        // �v���C���[1���S�[�������ꍇ
        if (player1Goal == 1 && player2Goal == 0)
        {
            // �v���C���[1�ɏ����A�j���[�V������ݒ�
            if (CompareTag("Player1"))
            {
                animator.SetBool("lose", true);
                Debug.Log("Player1 wins!");
            }
        }
        // �v���C���[2���S�[�������ꍇ
        else if (player2Goal == 1 && player1Goal == 0)
        {
            // �v���C���[2�ɏ����A�j���[�V������ݒ�
            if (CompareTag("Player2"))
            {
                animator.SetBool("win", true);
                Debug.Log("Player2 wins!");
            }
        }
    }
}
