using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isCorrectItem = false; // ���̃A�C�e�����������ǂ���

    // �A�C�e���̐�����ݒ�
    public void SetCorrect(bool isCorrect)
    {
        isCorrectItem = isCorrect;
    }
}
