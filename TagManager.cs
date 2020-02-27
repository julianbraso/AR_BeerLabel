using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagManager : MonoBehaviour {

    public string currentTag;

    public AnimManager currentAnimMgr;

    public bool bBusy;

    public Text textObj;

	// Use this for initialization
	void Start () {
		
	}
	
    public void SetTag(string s)
    {
        currentTag = s;
        if (textObj)
        {
            textObj.text = s;
        }
    }

	// Update is called once per frame
	void Update () {
        
	}
}
