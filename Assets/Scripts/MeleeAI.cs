using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : MonoBehaviour {

    private GameObject target;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find("PC");
	}
	
	// Update is called once per frame
	void Update ()
    {
        speed = Random.Range(.05f, .1f);
        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
