using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public float delay;
    bool started = false;
    float touchDuration;
    Touch touch;

    IEnumerator coroutine()
    {
        started = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SceneAgeVerification",LoadSceneMode.Single);
        Debug.Log("Loading scene...");
    }

	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.enabled = false;
        }
        StartCoroutine("coroutine");
	}

    void Update()
    {
        if (!started)
        {
            StartCoroutine("coroutine");
        }    
        if(Input.touchCount > 0){ //if there is any touch
            touchDuration += Time.deltaTime;
            touch = Input.GetTouch(0);
 
            if(touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
                SceneManager.LoadScene("SceneAgeVerification", LoadSceneMode.Single);
        }
        else
            touchDuration = 0.0f;
        }

    }


