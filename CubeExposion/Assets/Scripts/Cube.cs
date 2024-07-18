using UnityEngine;

[RequireComponent(typeof(Exploder), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
	[SerializeField] private int _explodeChance = 100;
	[SerializeField] private int _decreasingMultipier = 2;

	private Exploder _exploder;

	private void Awake()
	{
		_exploder = GetComponent<Exploder>();
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
		_exploder.Explode();
	}
}
