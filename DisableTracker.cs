using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTracker : MonoBehaviour {

    public CameraSettings camSettings;
    public GameObject tapHandler;

    public void EnableTapH()
    {
        tapHandler.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        tapHandler.SetActive(false);
        camSettings.EnableDisableTracker(false); ///enable = true / disable = false
	}
	
}