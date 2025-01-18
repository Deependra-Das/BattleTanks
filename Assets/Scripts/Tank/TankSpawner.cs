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

    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
       TankModel tankModel = new TankModel(_tankList[2].tankType, _tankList[2].movementSpeed, _tankList[2].movementSpeed, _tankList[2].tankMatColor);
       TankController tankController = new TankController(tankModel, _tankView);
    }


}
