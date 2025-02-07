using UnityEngine;

public class PlayerAnimationController2 : MonoBehaviour
{
    private Animator animator;

    private string winAnimation = "win";  // �����̃u�[���ϐ���
    private string loseAnimation = "lose";  // �s�k�̃u�[���ϐ���
    private string player2winAnimation = "2Pwin";
    private string player2loseAnimation = "2Plose";


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // �v���C���[���������ꍇ�ɌĂ΂��
    public void SetWinAnimation(bool state)
    {
        if (animator != null)
        {
            animator.SetBool(winAnimation, state);  // �����A�j���[�V�����̏�Ԃ�ݒ�
        }
    }

    // �v���C���[���������ꍇ�ɌĂ΂��
    public void SetLoseAnimation(bool state)
    {
        if (animator != null)
        {
            animator.SetBool(player2loseAnimation, state);  // �s�k�A�j���[�V�����̏�Ԃ�ݒ�
        }
    }
}
