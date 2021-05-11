using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPickaxe : Craftable
{
    private Craftable _craftable;

    private void Awake()
    {
        _craftable = GetComponent<Craftable>();
        Craftables.Add(Type, _craftable);
        SetInitialValues();
        BuildingTypesToModify = new BuildingType[1];
        BuildingTypesToModify[0] = BuildingType.DigSite;
    }
    private void Start()
    {
        SetDescriptionText("Enables building of the Dig Site to start gathering stones.");
    }
    private void DisplayConsole()
    {
        foreach (KeyValuePair<CraftingType, Craftable> kvp in Craftables)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }

    private void Update()
    {
        UpdateResourceCosts();
    }
}
