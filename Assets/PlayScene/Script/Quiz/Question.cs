using UnityEngine;

public class Question : MonoBehaviour
{
    private QuizManager quizManager;
    private QuizManager.QuestionAnswerPair currentQuestion;

    // �����ɐ����̃^�O���i�[���邽�߂̃t�B�[���h��ǉ�
    public string correctItemTag;  // �ǉ�

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        currentQuestion = quizManager.GetCurrentQuestion();  // ���݂̖��Ɖ𓚂̃y�A���擾
    }

    /// <summary>
    /// �n���ꂽ�A�C�e�����������ǂ����𔻒肷�郁�\�b�h�B
    /// </summary>
    /// <param name="item">�{�b�N�X�ɓ����ꂽ�A�C�e��</param>
    /// <returns>�����Ȃ�true�A�s�����Ȃ�false</returns>
    public bool CheckAnswer(GameObject item)
    {
        if (item != null)
        {
            // �A�C�e���̃��C���[�ƃ^�O�̃f�o�b�O�o��
            Debug.Log("�A�C�e���̃��C���[: " + LayerMask.LayerToName(item.layer));
            Debug.Log("�����̃^�O: " + correctItemTag);  // �����̃^�O��\��
            Debug.Log("�A�C�e���̃^�O: " + item.tag);

            // �A�C�e����"Item"���C���[���A�����̃^�O�ƈ�v���Ă��邩�m�F
            if (item.layer == LayerMask.NameToLayer("Item") && item.CompareTag(correctItemTag))
            {
                Debug.Log("�����I");
                return true;
            }
            else
            {
                Debug.Log("�s�����I");
                return false;
            }
        }
        return false;
    }
}
