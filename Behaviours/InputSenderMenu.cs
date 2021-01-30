using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSenderMenu : MonoBehaviour
{
    public GameObject ui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.SetActive(!ui.activeSelf);
            UI.on = ui.activeSelf;
        }
    }
}
