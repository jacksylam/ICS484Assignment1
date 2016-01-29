using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

    public float a;
    public float b;
    public float speed;

    private float x;
    private float y;
    private float z;
    private float theta = 0f * Mathf.Deg2Rad;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        float newX = a*Mathf.Cos(theta);
        float newZ = b*Mathf.Sin(theta);

        transform.Translate(new Vector3(newX,0,newZ) *Time.deltaTime *speed);

        theta = theta + 0.1f * Time.deltaTime;
        if (theta > Mathf.PI) {
            theta = 0f;
            transform.position = (new Vector3(x, y, z));
        }
       
	}
}
