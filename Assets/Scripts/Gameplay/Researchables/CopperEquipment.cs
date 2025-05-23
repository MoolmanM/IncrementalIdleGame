using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopperEquipment : Researchable
{
    private Researchable _researchable;

    void Awake()
    {
        _researchable = GetComponent<Researchable>();
        Researchables.Add(Type, _researchable);

        SetInitialValues();     
    }
    void Start()
    {      
        SetDescriptionText("Unlocks copper equipment");
    }
}
