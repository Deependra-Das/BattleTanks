using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    private ShellController _shellController;

    [SerializeField]
    private MeshRenderer _shellMesh;

    [SerializeField]
    private LayerMask _tankMask;

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
        return _tankMask;
    }

    private void OnTriggerEnter(Collider other)
    {
        float explosionForce = _shellController.GetExplosionForce();
        float explosionRadius = _shellController.GetExplosionRadius();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, GetLayerMask());
        for (int i = 0; i < colliders.Length; i++)
        {

            TankView tankView = colliders[i].GetComponent<TankView>();
            if(tankView!=null)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                if (!targetRigidbody)
                    continue;
                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

                float damage = CalculateDamage(targetRigidbody.position);
                tankView.TakeDamage(damage);
            }

            TargetView targetView = colliders[i].GetComponent<TargetView>();
            if (targetView != null)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
                if (!targetRigidbody)
                    continue;
                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                targetView.PlayTargetExplosion();

            }



        }

        PlayExplosion();

        Destroy(gameObject);
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
