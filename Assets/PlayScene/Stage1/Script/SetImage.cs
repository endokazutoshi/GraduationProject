using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    public Image image;
    private Sprite sprite;
    float randomInt = 0;


    // Use this for initialization
    void Start()
    {
        randomInt = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("������"+ randomInt);
        if (Input.GetButtonDown("X_Button_1P"))
        {
            Debug.Log("X�{�^����������܂����I");
            // X�{�^���������ꂽ�Ƃ��̏����������ɏ���
            Debug.Log("�摜���ύX����܂���");
            sprite = Resources.Load<Sprite>("mondai");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
      
    }
}