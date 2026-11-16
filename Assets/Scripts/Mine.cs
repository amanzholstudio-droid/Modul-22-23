using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Mine : MonoBehaviour 
{
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _detonationSec = 2f;
    [SerializeField] private float _radiusDetonation = 3f;
    [SerializeField] private float _radiusExplosion = 4f;
    [SerializeField] private ParticleSystem _effectExplosion;
    private bool _hasDetonation;
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _radiusDetonation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out _))
        {
            if (_hasDetonation == true) return;
            StartCoroutine(DetonationPerSecond());
        } 
    }

    private IEnumerator DetonationPerSecond()
    {
        _hasDetonation = true;
        yield return new WaitForSeconds(_detonationSec);
        Collider[] hits = Physics.OverlapSphere(transform.position, _radiusExplosion);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(_damage);
            }
        }

        if (_effectExplosion != null)
        {
            ParticleSystem effect = Instantiate(_effectExplosion, transform.position, Quaternion.identity);
            Destroy(effect.gameObject, effect.main.duration);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radiusDetonation);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusExplosion);
    }
}
