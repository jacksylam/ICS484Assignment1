using UnityEngine;
using System.Collections;

public class linerenderellipse : MonoBehaviour {

    public int segments;
    public float xradius;
    public float yradius;
    LineRenderer line;

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
        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
        xTemp = xradius;
        yTemp = 0.1f;
        reversex = true;
        reversey = true;
        Color start = Color.green;
        start.a = 0.2f;
        line.SetColors(start, start);
    }

  

    void CreatePoints() {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++) {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * 0.1f;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    void Update() {
        if (Time.time > nextActionTime) {
            nextActionTime = Time.time + period;
            if (xTemp > xradius) {
                reversex = true;
            }
            else if(xTemp < 1){
                reversex = false;
            }
            if (!reversex) {
                xTemp = xTemp + Random.Range(randomMin, randomMax);
            }
            else {
                xTemp = xTemp - Random.Range(randomMin, randomMax);
            }

            if (yTemp > yradius) {
                reversey = true;
            }
            else if (yTemp < 1) {
                reversey = false;
            }
            if (!reversey) {
                yTemp = yTemp + Random.Range(randomMin, randomMax);
            }
            else {
                yTemp = yTemp - Random.Range(randomMin, randomMax);
            }

            float x;
            float y;
            float z = 0f;

            float angle = 20f;
            for (int i = 0; i < (segments + 1); i++) {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * xTemp;
                y = Mathf.Cos(Mathf.Deg2Rad * angle) * yTemp;

                line.SetPosition(i, new Vector3(x, y, z));

                angle += (360f / segments);
            }

           line.transform.Rotate(Vector3.right * Time.deltaTime);
        }

        	offset += Random.Range(0.05f, 0.1f) * Time.deltaTime;
			line.material.SetTextureOffset("_MainTex", new Vector2(offset/3, offset));
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
