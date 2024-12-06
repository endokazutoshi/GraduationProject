using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;  // Singleton�C���X�^���X

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public int questionNumber;       // ���ԍ�
        public GameObject questionObject;  // ���I�u�W�F�N�g�i�Ⴆ��3D�I�u�W�F�N�g��UI�j
        public string correctAnswerTag;    // �����̃A�C�e���̃^�O�i������Őݒ�j
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // ���Ɖ𓚂̃y�A�̔z��

    private QuestionAnswerPair currentQuestion;  // ���݂̖��Ɛ����̃y�A
    private RangeChecker rangeChecker;  // RangeChecker�̎Q��

    void Awake()
    {
        // Singleton�̏�����
        if (Instance == null)
        {
            Instance = this;
        }

        // RangeChecker�̎Q�Ƃ�Awake�Ŏ擾
        rangeChecker = FindObjectOfType<RangeChecker>();
        if (rangeChecker == null)
        {
            Debug.LogError("RangeChecker��������܂���BHierarchy�ɒǉ����Ă��������B");
        }
    }

    void Start()
    {
        // ���������ɍŏ��̖���ݒ肷��
        SetQuestion(0);  // �����ł͖��ԍ�0���ŏ��̖��Ƃ��Đݒ肵�Ă��܂�

        // ���݂̖��I�u�W�F�N�g���A�N�e�B�u��
        ActivateCurrentQuestionObject();
    }

    // �w�肵�����ԍ��Ŗ���ݒ肷��
    public void SetQuestion(int questionNumber)
    {
        // �w�肵�����ԍ��ɊY�������������
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionNumber == questionNumber)
            {
                currentQuestion = pair;
                Debug.Log($"QuizManager�̌��݂̖���: {currentQuestion.questionObject.name}");
                Debug.Log($"QuizManager�̐����^�O��: {currentQuestion.correctAnswerTag}");
                Debug.Log($"QuizManager�̖��ԍ���: {currentQuestion.questionNumber}");
                return;
            }
        }

        // �Y�������肪������Ȃ��ꍇ
        Debug.LogError($"���ԍ� {questionNumber} ��������܂���ł����B");
    }

    // ���݂̖��I�u�W�F�N�g���A�N�e�B�u��
    private void ActivateCurrentQuestionObject()
    {
        // ���ׂĂ̖��I�u�W�F�N�g���A�N�e�B�u��
        foreach (var pair in questionAnswerPairs)
        {
            if (pair.questionObject != null)
            {
                pair.questionObject.SetActive(false);
            }
        }

        // ���݂̖��I�u�W�F�N�g���A�N�e�B�u��
        if (currentQuestion != null && currentQuestion.questionObject != null)
        {
            currentQuestion.questionObject.SetActive(false);
        }
    }

    // �𓚂��`�F�b�N���郁�\�b�h
    public bool CheckAnswer(string itemTag)
    {
        // �A�C�e���̃^�O�������̃^�O�ƈ�v���邩���m�F
        if (itemTag == currentQuestion.correctAnswerTag)
        {
            Debug.Log("����!");
            return true;  // ����
        }
        else
        {
            Debug.Log("�s����!");
            return false;  // �s����
        }
    }

    // ���݂̖���Ԃ����\�b�h
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // ���݂̖��ԍ���Ԃ����\�b�h
    public int GetCurrentQuestionNumber()
    {
        if (currentQuestion != null)
        {
            return currentQuestion.questionNumber;
        }
        else
        {
            Debug.LogError("���݂̖�肪�ݒ肳��Ă��܂���B");
            return -1;  // ��肪�ݒ肳��Ă��Ȃ��ꍇ��-1��Ԃ�
        }
    }
}
