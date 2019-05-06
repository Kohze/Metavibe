using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TextMesh helper_mesh = GameObject.Find("helperText").GetComponent<TextMesh>();
        helper_mesh.text = "testing";
	}
}
