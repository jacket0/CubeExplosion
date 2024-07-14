using UnityEngine;

public class Explosion : MonoBehaviour
{
	[SerializeField] private int _minCreatingCount = 2;
	[SerializeField] private int _maxCreatingCount = 6;
	[SerializeField] private int _decreasingMultipier = 2;
	[SerializeField] private Cube _cube;

	public void Splitting()
	{
		int creatingCount = Random.Range(_minCreatingCount, _maxCreatingCount);

		for (int i = 0; i < creatingCount; i++)
		{
			Cube newCube = Instantiate(_cube);
			newCube.transform.localScale /= _decreasingMultipier;
		}
	}
}
