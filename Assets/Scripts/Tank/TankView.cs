using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController _tankController;

    public TankView() {}

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }
}
