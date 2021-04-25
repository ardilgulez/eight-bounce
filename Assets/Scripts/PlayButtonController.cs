using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    public delegate void PlayButtonClick();
    public static event PlayButtonClick Click;

    public void OnPlayButtonClick()
    {
        Click();
    }
}
