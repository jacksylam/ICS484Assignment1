using UnityEngine;
using System.Collections;

public class ellpiseRotationLine : MonoBehaviour {

    public int segments;
    LineRenderer line;
    public bool reverse;


    private float offset;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/AdditiveCustom")); 
        line.SetVertexCount(segments);
        line.useWorldSpace = false;
        //CreatePoints();
        Color start = Color.green;
        start.a = 0.2f;
        line.SetColors(start, start);
        line.SetWidth(3F, 3F);
    }

  

    void CreatePoints() {

        float t = Time.time/3.0f;
        Vector3 pos;

        float j = 0;
        for (int i = 0; i < segments; i++) {

            if (reverse) {
                 pos = new Vector3(j + 0.5f, Mathf.Sin(i + t + 180), 0);
                 j = j + 0.3f;
            }
            else {
                 pos = new Vector3(j + 0.5f, Mathf.Sin(i + t), 0);
                 j = j + 0.3f;
            }
            line.SetPosition(i, pos);

        }
    }

    void Update() {
        CreatePoints();
        
        line.transform.Rotate(new Vector3(Random.Range(0f,1f) ,0,0)* Time.deltaTime);
        offset += Random.Range(0.05f, 0.1f) * Time.deltaTime;
	    line.material.SetTextureOffset("_MainTex", new Vector2(offset/3, offset));
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
