using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShellView : MonoBehaviour
{
    private ShellController _shellController;

    [SerializeField]
    private MeshRenderer _shellMesh;

    [SerializeField]
    private LayerMask _tankMask;

    [SerializeField]
    private LayerMask _enemyMask;

    [SerializeField]
    private Rigidbody _shellRB;

    [SerializeField]
    private ParticleSystem _explosionParticles;

    public void SetShellController(ShellController shellController)
    {
        _shellController = shellController;
    }
    public Rigidbody GetRigidBody()
    {
        return _shellRB;
    }
    public void ChangeColor(Material matColor)
    {
      _shellMesh.material = matColor;
    }
    public LayerMask GetLayerMask()
    {
        LayerMask mask = 0;

        if (_shellController.GetShellParentType() == ShellParentTypes.PlayerTank)
            mask = _tankMask;
        else if (_shellController.GetShellParentType() == ShellParentTypes.EnemyTank)
            mask = _enemyMask;

        return mask;
    }

    private void OnTriggerEnter(Collider other)
    {
        float explosionForce = _shellController.GetExplosionForce();
        float explosionRadius = _shellController.GetExplosionRadius();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, GetLayerMask());
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!rigidbody)
                continue;

            TankView tankView = colliders[i].GetComponent<TankView>();
            TargetView targetView = colliders[i].GetComponent<TargetView>();
            EnemyView enemyView = colliders[i].GetComponent<EnemyView>();

            if (tankView != null)
            {
                tankView.TakeDamage(ProcessShellCollisionForTank(rigidbody, explosionRadius, explosionForce));
            }

            else if (targetView != null)
            {
                ProcessShellCollisionForTarget(rigidbody, explosionRadius, explosionForce);
                targetView.PlayTargetExplosion();
            }

            else if (enemyView != null)
            {
                if (colliders[i] is SphereCollider)
                    continue;

                enemyView.TakeDamage(ProcessShellCollisionForEnemy(rigidbody, explosionRadius, explosionForce));

            }

        }

        PlayExplosion();

        Destroy(gameObject);
    }

    private float ProcessShellCollisionForTank(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        float damage = CalculateDamage(rigidbody.position);
        return damage;
    }
    private void ProcessShellCollisionForTarget(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
    }
    private float ProcessShellCollisionForEnemy(Rigidbody rigidbody, float explosionForce, float explosionRadius)
    {
        rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        float damage = CalculateDamage(rigidbody.position);
        return damage;
    }

    private void PlayExplosion()
    {
        _explosionParticles.transform.parent = null;
        _explosionParticles.Play();
        Destroy(_explosionParticles.gameObject, _explosionParticles.main.duration);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        float explosionRadius = _shellController.GetExplosionRadius();
        float maxDamage = _shellController.GetMaxDamage();

        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }

}
