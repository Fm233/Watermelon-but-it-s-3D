using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : MonoBehaviour
{
    public InputSender sender;
    public InputSenderConstant senderConstant;
    Vector3 lastPos;
    bool willSendLastPos = false;

    void Update()
    {
        Touch[] touches = Input.touches;
        Touch mainTouch = new Touch();
        bool existMainTouch = false;
        foreach (Touch touch in touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                mainTouch = touch;
                existMainTouch = true;
                break;
            }
        }
        if (existMainTouch)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mainTouch.position), out RaycastHit hit))
            {
                Vector3 pos = hit.point;
                pos.y = Const.FRUIT_SPAWN_Y;
                senderConstant.Send(pos);
                lastPos = pos;
                willSendLastPos = true;
            }
        }
        else
        {
            if (willSendLastPos)
            {
                willSendLastPos = false;
                sender.Send(lastPos);
            }
        }
    }
}
