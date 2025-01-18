using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel _tankModel;
    private TankView _tankView;

    public TankController(TankModel tankModel, TankView tankView)
    {
        _tankModel = tankModel;
        _tankModel.SetTankController(this);
        _tankView = tankView;
        _tankView.SetTankController(this);

        GameObject.Instantiate(tankView.gameObject);
    }
}
