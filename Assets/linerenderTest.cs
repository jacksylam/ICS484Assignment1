using UnityEngine;
using System.Collections;

public class linerenderTest : MonoBehaviour {

    public int segments;
    public float xRadius;
    public float yRadius;
    LineRenderer line;
    public bool reverse;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private float xTemp;
    private float yTemp;
    
    private bool reversex;
    private bool reversey;

    private float randomMin = 0f;
    private float randomMax = 0.05f;

    private float offset;

    void Start() {
        line = gameObject.GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/AdditiveCustom")); 
        line.SetVertexCount(segments);
        line.useWorldSpace = false;
        //CreatePoints();
        xTemp = xRadius;
        yTemp = 0.1f;
        reversex = true;
        reversey = true;
        Color start = Color.green;
        start.a = 0.2f;
        line.SetColors(start, start);
        line.SetWidth(3F, 3F);
    }

  

    void CreatePoints() {
        float x = 0f;
        float y = 0f;
        float z = 0f;
        
        float angle =75f;
        float t = Time.time/2.0f;
        Vector3 pos;

        for (int i = 0; i < (segments); i++) {

            if (reverse) {
                 pos = new Vector3(i + 0.5f, Mathf.Sin(i + t + 180), 0);
            }
            else {
                 pos = new Vector3(i + 0.5f, Mathf.Sin(i + t), 0);
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
