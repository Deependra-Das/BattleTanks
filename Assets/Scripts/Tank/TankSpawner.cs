using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField]
    private TankView _tankView;

    [System.Serializable]
    public class Tank
    {
        public TankTypes tankType;
        public float movementSpeed;
        public float rotationSpeed;
        public Material tankMatColor;
    }

    [SerializeField]
    private List<Tank> _tankList;

    public void CreateTank(TankTypes tankType)
    {
        Tank tank = null;
        switch (tankType)
        {
            case TankTypes.GreenTank:
                tank = _tankList[0];
                break;
            case TankTypes.BlueTank:
                tank = _tankList[1];
                break;
            case TankTypes.RedTank:
                tank = _tankList[2];
                break;
        }
        if (tank != null)
        {
            TankModel tankModel = new TankModel(
                tank.tankType,
                tank.movementSpeed,
                tank.movementSpeed,
                tank.tankMatColor
            );

            TankController tankController = new TankController(tankModel, _tankView);
        }
        else
        {
            Debug.Log("Tank data not found");
        }
    }


}
