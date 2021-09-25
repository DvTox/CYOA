using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonBehavior : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    Sprite _unPressedButtonState;
    [SerializeField]
    Sprite _pressedButtonState;
    #endregion

    public void OnPress(float time)
    {
        pressButton();
        //unPressButton();
        Invoke("unPressButton", time);
        Invoke("loadGame", time + 0.01f);
    }

    private void loadGame()
    {
       SceneManager.LoadScene(1);
    }

    private void unPressButton()
    {
        this.GetComponent<Image>().sprite = _unPressedButtonState;
    }

    private void pressButton()
    {
        this.GetComponent<Image>().sprite = _pressedButtonState;
    }
}
