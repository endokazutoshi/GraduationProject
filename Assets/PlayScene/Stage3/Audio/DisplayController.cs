using UnityEngine;
using UnityEngine.Audio;


public class DisplayController : MonoBehaviour
{
    public Camera display1Camera;
    public Camera display2Camera;

    void SwitchToDisplay1()
    {
        display1Camera.GetComponent<AudioListener>().enabled = true;
        display2Camera.GetComponent<AudioListener>().enabled = false;
    }

    void SwitchToDisplay2()
    {
        display1Camera.GetComponent<AudioListener>().enabled = false;
        display2Camera.GetComponent<AudioListener>().enabled = true;
    }
}
