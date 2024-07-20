using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Exploder : MonoBehaviour
{
	[field: SerializeField] public float ExplosionRadius { get; private set; } = 300f;

	[SerializeField] private float _explosionForce = 100f;
	[SerializeField] private int _decreasingMultipier = 2;

	private Spawner _spawner;

	private void Awake()
	{
		_spawner = GetComponent<Spawner>();
	}

	public void Explode()
	{
		_explosionForce *= _decreasingMultipier;
		ExplosionRadius *= _decreasingMultipier;
		Collider[] hits = Physics.OverlapSphere(transform.position, ExplosionRadius);

		foreach (Rigidbody explodableObject in _spawner.GetCubes(hits))
		{
			explodableObject.AddExplosionForce(_explosionForce, transform.position, ExplosionRadius);
		}
	}
}
