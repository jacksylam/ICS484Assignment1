using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Ellipse : MonoBehaviour {

    public float a = 5;
    public float b = 3;
    public float h = 1;
    public float k = 1;
    public float z = 1;
    public float theta = 45;
    public int resolution = 1000;
    public Material material;


    private Vector3[] positions;

    void Start() {
        positions = CreateEllipse(a, b, h, k, theta, resolution);
        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(resolution + 1);
        lr.SetColors(Color.green, Color.green);
        lr.material = material;
        for (int i = 0; i <= resolution; i++) {
            lr.SetPosition(i, positions[i]);
        }
    }

    void Update() {

    }

    Vector3[] CreateEllipse(float a, float b, float h, float k, float theta, int resolution) {

        positions = new Vector3[resolution + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 center = new Vector3(h, k, 0.0f);

        for (int i = 0; i <= resolution; i++) {
            float angle = (float)i / (float)resolution * 2.0f * Mathf.PI;
            positions[i] = new Vector3(b * Mathf.Sin(angle), z, a * Mathf.Cos(angle));
            positions[i] = q * positions[i] + center;
        }

        return positions;
    }

   

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}