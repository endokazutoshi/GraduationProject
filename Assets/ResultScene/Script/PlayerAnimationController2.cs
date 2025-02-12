using UnityEngine;

public class PlayerAnimationController2 : MonoBehaviour
{
    private Animator animator;

    private string winAnimation = "win";  // �����̃u�[���ϐ���
    private string loseAnimation = "lose";  // �s�k�̃u�[���ϐ���

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
        else
        {
            animator = GetComponent<Animator>();

            Debug.Log("animator�̂�����" + animator);

            animator.SetBool(winAnimation, state);  // �s�k�A�j���[�V�����̏�Ԃ�ݒ�

        }
    }

    // �v���C���[���������ꍇ�ɌĂ΂��
    public void SetLoseAnimation(bool state)
    {
        
        if (animator != null)
        {

            animator.SetBool(loseAnimation, state);  // �s�k�A�j���[�V�����̏�Ԃ�ݒ�
        }
        else
        {
            animator = GetComponent<Animator>();
            Debug.Log("Player2����������");

            Debug.Log("animator�̂�����" + animator);

            animator.SetBool(loseAnimation, state);  // �s�k�A�j���[�V�����̏�Ԃ�ݒ�

        }
    }
}
