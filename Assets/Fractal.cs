using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour {

	private static Vector3[] childDirections = {
		//Vector3.up,
		Vector3.right,
		Vector3.left,
		//Vector3.forward,
		//Vector3.back
	};

	private static Quaternion[] childOrientations = {
		//Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		//Quaternion.Euler(90f, 0f, 0f),
		//Quaternion.Euler(-90f, 0f, 0f)
	};

	public Mesh mesh;
	public Material material;
	public int maxDepth;
	public float childScale;
    public float maxRotationSpeed;
    public float spawnProbability;
    private float rotationSpeed;

    public float rotateX;
    public float rotateY;

	private int depth;

	private void Start () {
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
		if (depth < maxDepth) {
			StartCoroutine(CreateChildren());
		}
	}

	private IEnumerator CreateChildren () {
		for (int i = 0; i < childDirections.Length; i++) {
            if (Random.value < spawnProbability) {
                yield return new WaitForSeconds(0.0f);
                new GameObject("Fractal Child").AddComponent<Fractal>().
                    Initialize(this, i);
            }
		}
	}

	private void Initialize (Fractal parent, int childIndex) {
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition =
			childDirections[childIndex] * (0.5f + 0.5f * childScale);
		transform.localRotation = childOrientations[childIndex];
        maxRotationSpeed = parent.maxRotationSpeed; maxRotationSpeed = parent.maxRotationSpeed;
        spawnProbability = parent.spawnProbability;
	}

    private void Update() {
        transform.Rotate(0f, 30f * Time.deltaTime, 0f);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}