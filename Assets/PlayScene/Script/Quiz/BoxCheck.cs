using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    private QuizManager quizManager; // QuizManager���Q��

    void Start()
    {
        // QuizManager���擾
        quizManager = FindObjectOfType<QuizManager>();
    }

    // �A�C�e�����{�b�N�X�ɓ��ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void CheckItem(GameObject item)
    {
        if (quizManager != null)
        {
            // �N�C�Y�̐����A�C�e���Əƍ�
            if (item == quizManager.correctItem)
            {
                Debug.Log("�����̃A�C�e���ł��I");
            }
            else
            {
                Debug.Log("�s�����̃A�C�e���ł��I");
            }
        }
    }
}
