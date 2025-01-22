using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    private TankController _tankController;
    
    private float _movement;
    private float _rotation;

    [SerializeField]
    private Rigidbody _tankRB;

    [SerializeField]
    private MeshRenderer[] _tankMeshChildren;

    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private Image _fillImage;

    [SerializeField]
    private Color _fullHealthColor = Color.green;

    [SerializeField]
    private Color _zeroHealthColor = Color.red;

    [SerializeField]
    private GameObject _explosionPrefab;

    private ParticleSystem _explosionParticles;

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 5f, -7f);
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
    private void Awake()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _explosionParticles.gameObject.SetActive(false);
    }

    public void SetHealthUI()
    {
        _healthSlider.value = _tankController.GetCurrentHealth();

        _fillImage.color = Color.Lerp(_zeroHealthColor, _fullHealthColor, _tankController.GetCurrentHealth() / _tankController.GetInitialHealth());
    }

    public void TankExplosion()
    {
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        _tankController.TakeDamage(damage);
    }
}
