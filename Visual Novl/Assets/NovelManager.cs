using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelManager : MonoBehaviour {

    public static NovelManager singleton;

    [SerializeField] private Node Root, Current;
    [SerializeField] private Text quoteText, characterNameText;

    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private List<Text> optionText = new List<Text>();

    [SerializeField] private QuoteText quoteObj;

    void Awake(){
        singleton = this;
    }

	// Use this for initialization
	void Start () {
        Current = Root;
        quoteText.text = Root.getQuote();
        characterNameText.text = Root.getCharacterName();

    }

    public string getCurrentName() { return Current.getCharacterName(); }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            if(Current.getChildCount() > 0 && Current.getOptionsCount() == 0){
                quoteObj.startColorFade();
                Current = Current.getChild(0);
                characterNameText.text = Current.getCharacterName();
                quoteText.text = Current.getQuote();
            }
            else if (Current.getChildCount() > 0 && Current.getOptionsCount() > 0){
                Current.setOpponentAsCurrent();
                optionsPanel.SetActive(true);
                for(int i = 0; i < optionText.Count; i++){
                    optionText[i].text = Current.getOptionsAt(i);
                }
            }
        }
	}

    void LateUpdate(){
        quoteText.enabled = !optionsPanel.activeInHierarchy;
    }

    public void PickOption(int index){
        Current = Current.getChild(index);
        quoteObj.startColorFade();
        characterNameText.text = Current.getCharacterName();
        quoteText.text = Current.getQuote();
        optionsPanel.SetActive(false);
    }
}

[System.Serializable]
public class Node {

    [SerializeField] private Character character;
    [SerializeField] private string quote;
    [SerializeField] private Node parent;
    [SerializeField] private List<Node> child = new List<Node>();
    [SerializeField] private List<string> options = new List<string>();

    public string getQuote() { return quote; }
    public string getCharacterName() { return character.getName(); }
    public Node getParent() { return parent; }
    public Node getChild(int i) { return child[i]; }
    public int getChildCount() { return child.Count; }
    public string getOptionsAt(int i) { return options[i]; }
    public int getOptionsCount() { return options.Count; }
    public Character getCurrentCharacterOpponent() { return character.opponent; }
    public void setOpponentAsCurrent() { character = character.opponent; }
}
