using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ShellSpawner;

public class TankView : MonoBehaviour
{
    private TankController _tankController;

    public int playerNumber = 1;

    private float _movement;
    private float _rotation;

    [SerializeField]
    private Rigidbody _tankRB;

    [SerializeField]
    private MeshRenderer[] _tankMeshChildren;

    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private Slider _aimSlider;

    [SerializeField]
    private Image _fillImage;

    [SerializeField]
    private Color _fullHealthColor = Color.green;

    [SerializeField]
    private Color _zeroHealthColor = Color.red;

    [SerializeField]
    private GameObject _explosionPrefab;

    private ParticleSystem _explosionParticles;

    private string _fireButton;

    [SerializeField]
    private ShellSpawner _shellSpawner;

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 5f, -7f);
        
        _fireButton = "Fire" + playerNumber;
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

        TankShooting();
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
    private void TankShooting()
    {
        ResetUI();

        float currentLaunchForce = _tankController.GetCurrentLaunchForce();
        float maxLaunchForce = _tankController.GetMaxLaunchForce();
        float minLaunchForce = _tankController.GetMinLaunchForce();
        float chargeSpeed = _tankController.GetChargeSpeed();

        if (currentLaunchForce >= maxLaunchForce && !_tankController.HasFired())
        {
            currentLaunchForce = maxLaunchForce;
            _tankController.SetCurrentLaunchForce(currentLaunchForce);
            FireShell();
        }

        else if (Input.GetButtonDown(_fireButton))
        {
            _tankController.SetFired(false);
            currentLaunchForce = minLaunchForce;
        }
    
        else if (Input.GetButton(_fireButton) && !_tankController.HasFired())
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            _tankController.SetCurrentLaunchForce(currentLaunchForce);
            _aimSlider.value = currentLaunchForce;
        }
    
        else if (Input.GetButtonUp(_fireButton) && !_tankController.HasFired())
        {

            FireShell();
        }

    }
    private void FireShell()
    {
        _tankController.SetFired(true);
       
        Vector3 velocity = _tankController.GetCurrentLaunchForce() * _shellSpawner.transform.forward;

        _shellSpawner.SpawnShell(ShellTypes.Normal, velocity, _shellSpawner.transform);

        _tankController.SetCurrentLaunchForce(_tankController.GetMinLaunchForce());
    }

    public void ResetUI()
    {
        _aimSlider.value = _tankController.GetMinLaunchForce();
    }
}
