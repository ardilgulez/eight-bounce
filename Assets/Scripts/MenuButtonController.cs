using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public delegate void MenuButtonClick();
    public static event MenuButtonClick Click;

    public void OnMenuButtonClick()
    {
        Click();
    }
}
