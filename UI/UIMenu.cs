using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public Text updateText;
    public Button updateButton;

    public void Quit()
    {
        Application.Quit();
    }

    public void CheckUpdate()
    {
        StartCoroutine(CheckForUpdate.Check(updateText, updateButton));
    }
}
