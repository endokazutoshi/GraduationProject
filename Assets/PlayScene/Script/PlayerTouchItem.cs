using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchItem: MonoBehaviour
{
    public GameObject gameObject;
    public GameObject target;
    public bool isRelese; //’Ç‰Á

    //**********’Ç‰Á‚±‚±‚©‚ç**********
    void Start()
    {
        isRelese = true;
    }

    void Update()
    {
        if (CompareTag("Player1"))
        {
            if (Input.GetButtonDown("Touch_P1"))
            {
                transform.parent = null;
                isRelese = true;
            }
        }

        if(CompareTag("Player2"))
        {
            if(Input.GetButtonDown("Touch_P2"))
            {

            }
        }
    }
    //**********’Ç‰Á‚±‚±‚Ü‚Å**********

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube")
        {
            isRelese = false; //’Ç‰Á
            this.transform.position = new Vector3(target.transform.position.x, 0.5f, target.transform.position.z);
            transform.SetParent(gameObject.transform);
        }
    }
}
