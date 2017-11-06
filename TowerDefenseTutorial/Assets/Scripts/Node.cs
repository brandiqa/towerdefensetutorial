using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private Renderer rend;
    private Color defaultColor;    

	void Start () {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
	}

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }


}
