using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private EnemyController _enemyController;

    public int playerNumber = 1;

    private float _movement;
    private float _rotation;

    [SerializeField]
    private Rigidbody _enemyRB;

    [SerializeField]
    private MeshRenderer[] _enemyMeshChildren;

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

    [SerializeField]
    private ParticleSystem _explosionParticles;

    private string _fireButton;

    [SerializeField]
    private ShellSpawner _shellSpawner;

    private void Start()
    {
        _fireButton = "Fire" + playerNumber;
    }
    public EnemyView() { }

    void Update()
    {
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    public Rigidbody GetRigidBody()
    {
        return _enemyRB;
    }

    public void ChangeColor(Material matColor)
    {
        for (int i = 0; i < _enemyMeshChildren.Length; i++)
        {
            _enemyMeshChildren[i].material = matColor;
        }
    }
    private void Awake()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _explosionParticles.gameObject.SetActive(false);
    }

    public void SetHealthUI()
    {
        _healthSlider.value = _enemyController.GetCurrentHealth();

        _fillImage.color = Color.Lerp(_zeroHealthColor, _fullHealthColor, _enemyController.GetCurrentHealth() / _enemyController.GetInitialHealth());
    }

    public void EnemyExplosion()
    {
        _explosionParticles.transform.position = transform.position;
        _explosionParticles.gameObject.SetActive(true);

        _explosionParticles.Play();
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        _enemyController.TakeDamage(damage);
    }
    private void EnemyShooting()
    {
        ResetUI();

        float currentLaunchForce = _enemyController.GetCurrentLaunchForce();
        float maxLaunchForce = _enemyController.GetMaxLaunchForce();
        float minLaunchForce = _enemyController.GetMinLaunchForce();
        float chargeSpeed = _enemyController.GetChargeSpeed();

        if (currentLaunchForce >= maxLaunchForce && !_enemyController.HasFired())
        {
            currentLaunchForce = maxLaunchForce;
            _enemyController.SetCurrentLaunchForce(currentLaunchForce);
            FireShell();
        }

        else if (Input.GetButtonDown(_fireButton))
        {
            _enemyController.SetFired(false);
            currentLaunchForce = minLaunchForce;
        }

        else if (Input.GetButton(_fireButton) && !_enemyController.HasFired())
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            _enemyController.SetCurrentLaunchForce(currentLaunchForce);
            _aimSlider.value = currentLaunchForce;
        }

        else if (Input.GetButtonUp(_fireButton) && !_enemyController.HasFired())
        {

            FireShell();
        }

    }
    private void FireShell()
    {
        _enemyController.SetFired(true);

        Vector3 velocity = _enemyController.GetCurrentLaunchForce() * _shellSpawner.transform.forward;

        _shellSpawner.SpawnShell(ShellTypes.Normal, velocity, _shellSpawner.transform);

        _enemyController.SetCurrentLaunchForce(_enemyController.GetMinLaunchForce());
    }

    public void ResetUI()
    {
        _aimSlider.value = _enemyController.GetMinLaunchForce();
    }
    public void SetCameraPosition(Transform spawnTransform)
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);

        cam.transform.position = spawnTransform.position;
        cam.transform.localPosition = new Vector3(0f, 3f, -5f);
    }
}
