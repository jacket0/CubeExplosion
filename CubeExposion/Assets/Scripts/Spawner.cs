using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private int _minCreatingCount = 2;
	[SerializeField] private int _maxCreatingCount = 6;
	[SerializeField] private int _decreasingMultipier = 2;
	[SerializeField] private Cube _cube;

	private List<Cube> _cubes;

	public List<Rigidbody> GetCubes()
	{
		CreateNewCubes();

		List<Rigidbody> explosionCubes = new();

		for (int i = 0; i < _cubes.Count; i++)
		{
			if (_cubes[i].TryGetComponent(out Rigidbody rigidbody))
			{
				explosionCubes.Add(rigidbody);
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
