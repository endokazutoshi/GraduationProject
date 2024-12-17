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
        Debug.Log("乱数は"+ randomInt);
        if (Input.GetButtonDown("X_Button_1P"))
        {
            Debug.Log("Xボタンが押されました！");
            // Xボタンが押されたときの処理をここに書く
            Debug.Log("画像が変更されました");
            sprite = Resources.Load<Sprite>("mondai");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
      
    }
}