using UnityEngine;

public class Exploder : MonoBehaviour
{
	[field: SerializeField] public float ExplosionRadius { get; private set; } = 300f;

	[SerializeField] private float _explosionForce = 100f;

	private Spawner _spawner;

	private void Awake()
	{
		_spawner = GetComponent<Spawner>();
	}

	public void Explode()
	{
		Collider[] hits = Physics.OverlapSphere(transform.position, ExplosionRadius);

		foreach (Rigidbody explodableObject in _spawner.GetNewCubes(hits))
		{
			explodableObject.AddExplosionForce(_explosionForce, transform.position, ExplosionRadius);
		}
	}
}
