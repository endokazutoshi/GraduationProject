using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
    }

    public void CheckItem(GameObject item)
    {
        // ���݂̖����擾
        QuizManager.QuestionAnswerPair currentQuestion = quizManager.GetCurrentQuestion();

        if (currentQuestion != null)
        {
            // ���݂̖��̐����^�O���擾
            string correctAnswerTag = currentQuestion.correctAnswerTag;

            // �������ǂ������`�F�b�N
            if (item.CompareTag(correctAnswerTag))
            {
                Debug.Log("�����ł��I");
            }
            else
            {
                Debug.Log("�s�����ł��I");
            }
        }
        else
        {
            Debug.LogError("���݂̖�肪����܂���");
        }
    }
}
