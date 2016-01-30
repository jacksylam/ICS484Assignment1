using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

    public float a;
    public float b;
    public float speed;
    public bool reversed;

    private float x;
    private float y;
    private float z;
    private float theta = 0f;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

        float tempTheta = theta * Mathf.Deg2Rad;
		moveSphere(tempTheta);
			theta = theta + 5 * Time.deltaTime;
			if (theta > 180) {
                theta = 0f;
                gameObject.GetComponent<TrailRenderer>().enabled = false;    
                transform.position = (new Vector3(x, y, z));
                Destroy(gameObject);
              // gameObject.GetComponent<TrailRenderer>().enabled = false;    
            }
	}

    private void moveSphere(float theta) {
        float newX = a * Mathf.Cos(theta);
        float newZ = b * Mathf.Sin(theta);
        if (reversed) {
            transform.Translate(new Vector3(-1*newX, 0, newZ) * Time.deltaTime * speed);

        }
        else {
            transform.Translate(new Vector3(newX, 0, newZ) * Time.deltaTime * speed);

        }
       
    }
}
