using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;  // Singleton�C���X�^���X

    [System.Serializable]
    public class QuestionAnswerPair
    {
        public GameObject questionObject;  // ���I�u�W�F�N�g
        public string correctAnswerTag;    // �����̃A�C�e���̃^�O�i������Őݒ�j
    }

    public QuestionAnswerPair[] questionAnswerPairs;  // ���Ɖ𓚂̃y�A�̔z��

    private QuestionAnswerPair currentQuestion;  // ���݂̖��Ɛ����̃y�A

    public RangeChecker rangeChecker;  // RangeChecker �X�N���v�g���Q��

    void Awake()
    {
        // Singleton�̏�����
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // �������Ń����_���Ȗ���ݒ�
        if (rangeChecker != null)
        {
            rangeChecker.SetRandomQuestion();  // RangeChecker�Ƀ����_���Ȗ��ݒ�
        }
    }

    // ���݂̖���Ԃ�
    public QuestionAnswerPair GetCurrentQuestion()
    {
        return currentQuestion;
    }

    // ���݂̖���RangeChecker����ݒ�
    public void SetCurrentQuestionFromRangeChecker(GameObject question, string correctAnswerTag)
    {
        currentQuestion = new QuestionAnswerPair
        {
            questionObject = question,
            correctAnswerTag = correctAnswerTag
        };

        Debug.Log("���݂̖��: " + currentQuestion.questionObject.name);
        Debug.Log("�����^�O: " + currentQuestion.correctAnswerTag);
    }
}
