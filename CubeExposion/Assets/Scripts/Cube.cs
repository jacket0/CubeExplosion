using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class Cube : MonoBehaviour
{
	[SerializeField] private float _explosionForce = 100f;
	[SerializeField] private float _explosionRadius = 10f;
	[SerializeField] private int _explodeChance = 100;
	[SerializeField] private int _decreasingMultipier = 2;
	[SerializeField] private Cube _cube;

	private Spawner _spawner;

	private void Awake()
	{
		_spawner = GetComponent<Spawner>();
		GetComponent<Renderer>().material.color = Random.ColorHSV();
	}

	private void OnMouseDown()
	{
		if (_explodeChance >= Random.Range(0, 100))
		{
			_explodeChance /= _decreasingMultipier;
			ExplodeCube();
		}
	}

	private void ExplodeCube()
	{
		Destroy(gameObject);
		_spawner.CreateNewCubes();

		foreach (Rigidbody explodableObject in GetExplodableObjects())
		{
			explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
		}
	}

	private List<Rigidbody> GetExplodableObjects()
	{
		Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

		List<Rigidbody> explosionCubes = new();

		foreach (Collider hit in hits)
		{
			if (hit.attachedRigidbody != null)
				explosionCubes.Add(hit.attachedRigidbody);
		}

		return explosionCubes;
	}
}
