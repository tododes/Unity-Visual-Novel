using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Character opponent;

    [SerializeField]
    private string Name;
    private NovelManager manager;
    private MeshRenderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        manager = NovelManager.singleton;
	}
	
	// Update is called once per frame
	void Update () {
        rend.enabled = (manager.getCurrentName() == Name);
	}

    public string getName() { return Name; }
}
