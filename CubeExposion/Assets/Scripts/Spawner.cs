using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private int _minCreatingCount = 2;
	[SerializeField] private int _maxCreatingCount = 6;
	[SerializeField] private int _decreasingMultipier = 2;
	[SerializeField] private Cube _cube;

	public List<Rigidbody> GetCubes(Collider[] hits)
	{
		CreateNewCubes();

		List<Rigidbody> explosionCubes = new();

		foreach (var hit in hits)
		{
			if (hit.attachedRigidbody != null)
				explosionCubes.Add(hit.attachedRigidbody);
		}

		return explosionCubes;
	}

	private void CreateNewCubes()
	{
		int creatingCount = Random.Range(_minCreatingCount, _maxCreatingCount);

		for (int i = 0; i < creatingCount; i++)
		{
			Cube newCube = Instantiate(_cube);
			newCube.transform.localScale /= _decreasingMultipier;
		}
	}
}
