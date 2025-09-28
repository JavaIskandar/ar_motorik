using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButton : MonoBehaviour {
    public List <GameObject> objectToActive;
    public List <GameObject> objectToDisable;
	
	// Update is called once per frame
	public virtual void OnClick () {
		foreach(GameObject item in objectToActive)
        {
            item.SetActive(true);
        }
        foreach (GameObject item in objectToDisable)
        {
            item.SetActive(false);
        }
    }
}
