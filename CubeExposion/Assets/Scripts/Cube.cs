using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
public class Cube : MonoBehaviour
{
	[SerializeField] private float _explosionForce = 100f;
	[SerializeField] private float _explosionRadius = 10f;
	[SerializeField] private int _explodeChance = 100;
	[SerializeField] private Cube _cube;

	private Explosion _explosion;

	private void Awake()
	{
		_explosion = GetComponent<Explosion>();
		GetComponent<Renderer>().material.color = Random.ColorHSV();
	}

	private void OnMouseDown()
	{
		ExplodeCube();
	}

	private void ExplodeCube()
	{
		int newChance = Random.Range(0, 100);

		if (_explodeChance >= newChance)
		{
			_explodeChance /= 2;
			Destroy(gameObject);
			_explosion.Splitting();

			foreach (Rigidbody explodableObject in GetExplodableObjects())
			{
				explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
			}
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
