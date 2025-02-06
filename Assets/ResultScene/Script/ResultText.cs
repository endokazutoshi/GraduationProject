using UnityEngine;

public class ResultText : MonoBehaviour
{
    public GameObject WinText1P;
    public GameObject LoseText1P;
    public GameObject WinText2P;
    public GameObject LoseText2P;
    public PlayerAnimationController playerAnimationController;  // PlayerAnimationController �ւ̎Q��

    void Start()
    {
        // �ŏ��ɑS�Ĕ�\���ɐݒ�
        WinText1P.SetActive(false);
        LoseText1P.SetActive(false);
        WinText2P.SetActive(false);
        LoseText2P.SetActive(false);

        // PlayerPrefs ����S�[������ǂݍ���
        int player1Goal = PlayerPrefs.GetInt("Player1Goal", 0);  // �f�t�H���g�l��0
        int player2Goal = PlayerPrefs.GetInt("Player2Goal", 0);  // �f�t�H���g�l��0

        // �S�[�������f�o�b�O�Ŋm�F
        Debug.Log("Player1 Goal: " + player1Goal);
        Debug.Log("Player2 Goal: " + player2Goal);

        // �v���C���[1���S�[�������ꍇ
        if (player1Goal == 1 && player2Goal == 0)
        {
            WinText1P.SetActive(true);  // �v���C���[1�̏���
            LoseText2P.SetActive(true); // �v���C���[2�̔s�k
            // PlayerAnimationController �ɃS�[���̏���n���ăA�j���[�V������ݒ�
            playerAnimationController.SetPlayerGoal(player1Goal, player2Goal);
        }
        // �v���C���[2���S�[�������ꍇ
        else if (player2Goal == 1 && player1Goal == 0)
        {
            WinText2P.SetActive(true);  // �v���C���[2�̏���
            LoseText1P.SetActive(true); // �v���C���[1�̔s�k
            // PlayerAnimationController �ɃS�[���̏���n���ăA�j���[�V������ݒ�
            playerAnimationController.SetPlayerGoal(player1Goal, player2Goal);
        }
        // �������S�[�������ꍇ�i�s���ȏ�ԁj
        else
        {
            Debug.LogWarning("�s���ȃS�[����Ԃł��B�����̃v���C���[���S�[�����Ă���\��������܂��B");
        }
    }
}
