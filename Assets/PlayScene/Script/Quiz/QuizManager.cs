using UnityEngine;

public class QuizManager : MonoBehaviour
{
    // ���ɑΉ����鐳���A�C�e��
    public GameObject correctItem;

    // �����e�i�Ⴆ�΃N�C�Y�̃^�C�g��������j
    public string quizQuestion;

    // ���݂̖�肪�������ǂ������m�F���邽�߂ɃA�C�e����n�����\�b�h
    public void SetCorrectItem(GameObject item)
    {
        correctItem = item;
    }

    // �N�C�Y�̖����e���擾
    public string GetCurrentQuiz()
    {
        return quizQuestion;
    }
}
