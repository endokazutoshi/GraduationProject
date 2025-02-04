using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifeTime = 8f; // �I�u�W�F�N�g��������܂ł̎���
    public float textAppearTime = 4f; // �e�L�X�g��\�����n�߂鎞��
    public GameObject[] countdownObjects; // �b�����Ƃɕ\������I�u�W�F�N�g�z��

    void Start()
    {
        // �ŏ��͂��ׂẴI�u�W�F�N�g���\���ɂ���
        foreach (GameObject obj in countdownObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(ManageObjectLifecycle());
    }

    IEnumerator ManageObjectLifecycle()
    {
        yield return new WaitForSeconds(textAppearTime); // �w�莞�ԑҋ@

        // �b�����ƂɃI�u�W�F�N�g��\��
        for (int i = 0; i < countdownObjects.Length; i++)
        {
            countdownObjects[i].SetActive(true); // �Ώۂ̃I�u�W�F�N�g��\��
            yield return new WaitForSeconds(1f); // 1�b�҂�
            countdownObjects[i].SetActive(false); // 1�b��ɔ�\���ɂ���
        }

        yield return new WaitForSeconds(lifeTime - textAppearTime - countdownObjects.Length); // �c��̎��ԑҋ@
        Destroy(gameObject); // �I�u�W�F�N�g���폜
    }
}
