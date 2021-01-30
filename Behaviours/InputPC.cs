using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : MonoBehaviour
{
    public InputSender sender;
    public InputSenderConstant senderConstant;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Vector3 pos = hit.point;
            pos.y = Const.FRUIT_SPAWN_Y;
            senderConstant.Send(pos);
            if (Input.GetMouseButtonDown(0))
            {
                sender.Send(pos);
            }
        }
    }
}
