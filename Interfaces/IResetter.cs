using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResetter
{
    void AddResetable(IResetable resetable);
    void ResetAll();
}
