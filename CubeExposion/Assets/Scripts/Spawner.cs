using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private int _minCreatingCount = 2;
	[SerializeField] private int _maxCreatingCount = 6;
	[SerializeField] private int _decreasingMultipier = 2;
	[SerializeField] private Cube _cube;

	private List<Cube> _cubes;

	public List<Rigidbody> GetNewCubes(Collider[] hits)
	{
		CreateNewCubes();

		List<Rigidbody> explosionCubes = new();

		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i].TryGetComponent(out Cube cube))
			{
				if (hits[i].attachedRigidbody != null && _cubes.Contains(cube))
					explosionCubes.Add(hits[i].attachedRigidbody);
			}
		}

		return explosionCubes;
	}

	private void CreateNewCubes()
	{
		int creatingCount = Random.Range(_minCreatingCount, _maxCreatingCount);
		_cubes = new List<Cube>();

		for (int i = 0; i < creatingCount; i++)
		{
			Cube newCube = Instantiate(_cube);
			newCube.transform.localScale /= _decreasingMultipier;
			_cubes.Add(newCube);
		}
	}
}
