using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject[] targetObject;
    private SceneManagerController sceneManagerController;

    void Start()
    {
        sceneManagerController = FindObjectOfType<SceneManagerController>();
    }

    void Update()
    {
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return; // “ü—Í‚ğ–³Œø‰»

        // D-Pad ¶‚Ì“ü—Í
        if (Input.GetAxis("DpadHorizontal") < 0)
        {
            targetObject[0].SetActive(true);
            Debug.Log("D-Pad ¶‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
        }
        else
        {
            targetObject[0].SetActive(false);
        }

        // D-Pad ‰E‚Ì“ü—Í
        if (Input.GetAxis("DpadHorizontal") > 0)
        {
            targetObject[1].SetActive(true);
            Debug.Log("D-Pad ‰E‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
        }
        else
        {
            targetObject[1].SetActive(false);
        }
    }
}
