using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;

    private Renderer rend;
    private Color defaultColor;

    private GameObject turret;
    public Vector3 positionOffset;

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

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build here!");
            return;
        }

        // Build Turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret =(GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }


}
