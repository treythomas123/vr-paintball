using UnityEngine;
using System.Collections;

public class MovingTarget : MonoBehaviour {

    public GameObject target;
    public GameObject firstPoint;
    public GameObject secondPoint;
    public float speed;

    private Vector3 goal;

	// Use this for initialization
	void Start () {
        target.transform.position = firstPoint.transform.position;
        goal = secondPoint.transform.position;
    }
    
	// Update is called once per frame
	void Update () {
        target.transform.position = Vector3.MoveTowards(target.transform.position, goal, speed * Time.deltaTime);
        if (target.transform.position == goal) {
            if (goal == firstPoint.transform.position) {
                goal = secondPoint.transform.position;
            } else
            {
                goal = firstPoint.transform.position;
            }
        }
    }
}
