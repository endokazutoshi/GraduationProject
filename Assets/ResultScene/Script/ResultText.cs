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
        // PlayerPrefs ����S�[������ǂݍ���
        int player1Goal = PlayerPrefs.GetInt("Player1Goal", 0);  // �f�t�H���g�l��0
        int player2Goal = PlayerPrefs.GetInt("Player2Goal", 0);  // �f�t�H���g�l��0

        // �v���C���[1���S�[�������ꍇ
        if (player1Goal == 1 && player2Goal == 0)
        {
            Debug.Log("playergoal1  "+ player1Goal);
            Debug.Log("playergoal2  " + player2Goal);
            WinText1P.SetActive(true);  // �v���C���[1�̏���
            LoseText2P.SetActive(true); // �v���C���[2�̔s�k
        }
        // �v���C���[2���S�[�������ꍇ
        else if (player2Goal == 1 && player1Goal == 0)
        {
            Debug.Log("playergoal1  " + player1Goal);
            Debug.Log("playergoal2  " + player2Goal);
            WinText2P.SetActive(true);  // �v���C���[2�̏���
            LoseText1P.SetActive(true); // �v���C���[1�̔s�k
        }
        // �������S�[�������ꍇ�͕\�����Ȃ��i�s���ȏ�ԁj
        else
        {
            Debug.LogWarning("�s���ȃS�[����Ԃł��B�����̃v���C���[���S�[�����Ă���\��������܂��B");
        }
    }
}
