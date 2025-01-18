using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController _tankController;
    
    private float _movement;
    private float _rotation;

    [SerializeField]
    private Rigidbody _tankRB;

    [SerializeField]
    private MeshRenderer[] _tankMeshChildren;

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }
    public TankView() {}

    void Update()
    {
        TankMovement();

        if(_movement!=0)
        {
            _tankController.Move(_movement,_tankController.GetMovementSpeed());
        }
        if (_rotation != 0)
        {
            _tankController.Rotate(_rotation, _tankController.GetRotationSpeed());
        }
    }

    private void TankMovement()
    {
        _movement = Input.GetAxis("Vertical");
        _rotation = Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController tankController)
    {
        _tankController = tankController;
    }

    public Rigidbody GetRigidBody()
    {
        return _tankRB;
    }

    public void ChangeColor(Material matColor)
    {
        for(int i=0;i< _tankMeshChildren.Length;i++)
        {
            _tankMeshChildren[i].material = matColor;
        }
    }

}
