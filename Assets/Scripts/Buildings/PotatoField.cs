﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotatoField : Building
{
    private Building _building;

    private void Awake()
    {
        _building = GetComponent<Building>();
        _buildings.Add(Type, _building);

    }

    private void Start()
    {
        SetInitialValues();
        SetDescriptionText();
        //DisplayConsole();
    }

    private void DisplayConsole()
    {
        foreach (KeyValuePair<BuildingType, Building> kvp in _buildings)
        {
            Debug.Log(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
        }
    }

    public override void Build()
    {
        base.Build();
    }

    private void Update()
    {
        UpdateResourceCosts();
    }
}
