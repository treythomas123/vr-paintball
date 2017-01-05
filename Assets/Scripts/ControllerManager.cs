using UnityEngine;
using System.Collections;

public class ControllerManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public Rigidbody paintballPrefab;
    public Transform firePosition;

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Rigidbody paintball;
            paintball = Instantiate(paintballPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
            paintball.AddForce(firePosition.forward * 2000);
        }
	}
}
