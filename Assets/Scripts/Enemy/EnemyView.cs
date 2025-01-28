using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyView : MonoBehaviour
{
    private EnemyController _enemyController;

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

    private Transform[] _waypoints;
    private Transform _playerTransform;
    private float _waitTimeAtWaypoint;
    private float _shootingCooldown;
    private float _shootingRange;
    private float _lastShootTime = 0f;

    private int _currentWaypointIndex;
    private bool _movingForward = true;
    private bool _isPatrolling = false;
    private bool _playerInRange = false;
    private bool _playerInShootingRange = false;
    private float _currentLaunchForce = 0f;

    private Coroutine patrolCoroutine;

    [SerializeField]
    private ShellSpawner _shellSpawner;
    private void Awake()
    {
        _explosionParticles = Instantiate(_explosionPrefab).GetComponent<ParticleSystem>();
        _explosionParticles.gameObject.SetActive(false);
    }

    public EnemyView() { }

    public void SetEnemyController(EnemyController enemyController)
    {
        _enemyController = enemyController;
    }

    void Update()
    {
        if (_playerInRange)
        {
            DetectPlayer();
            if (_playerInShootingRange)
            {
                RotateTowardsPlayer();
                ShootAtPlayer();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            if (!_isPatrolling)
            {
                _isPatrolling = true;
                patrolCoroutine = StartCoroutine(PatrolRoutine());
            }
        }
    }

    private void DetectPlayer()
    {
        if(_playerTransform!=null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);
            if (distanceToPlayer <= _shootingRange)
            {
                _playerInShootingRange = true;
            }
            else
            {
                _playerInShootingRange = false;
            }
        }
      
    }

    private void MoveTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            Vector3 direction = _playerTransform.position - transform.position;
            transform.position += direction.normalized * _enemyController.GetMovementSpeed() * Time.deltaTime;
        }
    }

    private void RotateTowardsPlayer()
    {
        if (_playerTransform != null)
        {
            //Vector3 direction = (_playerTransform.position - transform.position).normalized;

            //Quaternion lookRotation = Quaternion.LookRotation(direction);

            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _enemyController.GetRotationSpeed() * Time.deltaTime);
            //Debug.Log(direction.ToString()+" "+lookRotation.ToString() +" "+ transform.rotation.ToString());
            transform.LookAt(_playerTransform);
        }
    }

    private void ShootAtPlayer()
    {
        if (Time.time - _lastShootTime >= _shootingCooldown)
        {
            FireShell();
            _lastShootTime = Time.time;
        }
    }

    private IEnumerator PatrolRoutine()
    {
        while (_isPatrolling)
        {
            if (_waypoints.Length == 0) yield break;

            Transform targetWaypoint = _waypoints[_currentWaypointIndex];
            ;

            while (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
            {
                Vector3 direction = (targetWaypoint.position - transform.position).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _enemyController.GetRotationSpeed() * Time.deltaTime);

                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _enemyController.GetMovementSpeed() * Time.deltaTime);

                yield return null;
            }

            yield return new WaitForSeconds(_waitTimeAtWaypoint);


            if (_movingForward)
            {
                if (_currentWaypointIndex < _waypoints.Length - 1)
                    _currentWaypointIndex++;
                else
                    _movingForward = false;
            }
            else
            {
                if (_currentWaypointIndex > 0)
                    _currentWaypointIndex--;
                else
                    _movingForward = true;
            }
        }
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
        Destroy(_explosionParticles.gameObject, _explosionParticles.main.duration);
        Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        _enemyController.TakeDamage(damage);
    }

    private void FireShell()
    {
        _currentLaunchForce = _enemyController.GetMaxLaunchForce();

        Vector3 velocity = _currentLaunchForce * _shellSpawner.transform.forward;

        _shellSpawner.SpawnShell(ShellTypes.Normal, velocity, _shellSpawner.transform, ShellParentTypes.EnemyTank);

    }

    public void SetCameraPosition(Transform spawnTransform)
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);

        cam.transform.position = spawnTransform.position;
        cam.transform.localPosition = new Vector3(0f, 3f, -5f);
    }
    public void SetPatrolWaypoints(Transform[] waypoints) => _waypoints = waypoints; 
    public void SetWaitTimeAtWaypoint(float waitTimeAtWaypoint) => _waitTimeAtWaypoint = waitTimeAtWaypoint;
    public void SetShootingCooldown(float shootingCooldown) => _shootingCooldown = shootingCooldown;
    public void SetShootingRange(float shootingRange) => _shootingRange = shootingRange;
    public float GetShootingRange()
    {
        return _shootingRange;
    }
    
    public void SetPlayerInRange(bool value) => _playerInRange = value;
    public void SetPlayerTransform(Transform value) => _playerTransform = value;
    public Transform GetPlayerTransform()
    {
        return _playerTransform;
    }
    public void SetPlayerInShootingRange(bool value) => _playerInShootingRange = value;
    public bool GetPlayerInShootingRange()
    {
        return _playerInShootingRange;
    }
    public void PausePatrolling()
    {
        if (patrolCoroutine != null)
        {
            StopCoroutine(patrolCoroutine);
            patrolCoroutine = null;
        }

        _isPatrolling = false;
    }
    public void ResumePatrolling()
    {
        if (!_isPatrolling)
        {
            _isPatrolling = true;
            patrolCoroutine = StartCoroutine(PatrolRoutine());
        }
    }

    public Transform GetEnemyTransform()
    {
        return gameObject.transform;
    }
}
