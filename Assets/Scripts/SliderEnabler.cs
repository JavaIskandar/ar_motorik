using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEnabler : ObjectEnabler
{
    public override void Interact()
    {
        base.Interact();
        GameManager.GetInstance().ForwardSliderButton.FillStack(enabledObjects[0].transform);
    }
}
