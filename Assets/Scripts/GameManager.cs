using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    GameObject
        _buttonPrefab,
        _buttonContainer;
    [SerializeField]
    Sprite _ChoiceButtonPressedState;
    [SerializeField]
    VideoPlayer _videoPlayer;
    [SerializeField]
    videoObject[] _videos;
    #endregion
    #region Properties
    private videoObject CurrenVideoObject { get; set; }
    private List<GameObject> Buttons { get; set; }
    private bool BlockButtonCreation { get; set; }
    #endregion

    void Start()
    {
        CurrenVideoObject = _videos[0];
        Buttons = new List<GameObject>(4);
    }

    public void Update()
    {
        if (_videoPlayer.time == CurrenVideoObject.ChoiceTime)
        {
            createButtons();
        }
    }

    private void createButtons()
    {
        if (BlockButtonCreation) return;

        foreach (var choice in CurrenVideoObject.choices)
        {
            var obj = Instantiate(_buttonPrefab, _buttonContainer.transform);
            obj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = choice.Text;
            obj.GetComponent<Button>().onClick.AddListener(() => onChoiceButtonPress(ref obj,ref _videos[choice.NextVideo]));

            Buttons.Add(obj);
        }
        BlockButtonCreation = true;
    }

    private void onChoiceButtonPress(ref GameObject button,ref videoObject videoObject)
    {
        button.GetComponent<Image>().sprite = _ChoiceButtonPressedState;

        CurrenVideoObject = videoObject;
        _videoPlayer.clip = videoObject.Video;
        destroyButtons();
    }



    private void destroyButtons()
    {
        foreach (var button in Buttons)
        {
            DestroyImmediate(button);
        }
        BlockButtonCreation = false;
    }
}
