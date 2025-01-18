using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController _tankController;

    public TankModel() {}

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }
}
