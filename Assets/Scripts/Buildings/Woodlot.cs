﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodlot : Building
{
    private Building _building;
    private BuildingUI _ui;
    private Collector collector;
    private float _timer = 1f;
    private float maxValue = 0.1f;

    public override void HandleCollector(ref Collector collector)
    {
        SelfCount = 5;
        collector.buildingMultiplier = (float)0.13;
        collector.type = ResourceType.Sticks;

        base.HandleCollector(ref collector);
    }

    private void Awake()
    {
        _building = GetComponent<Building>();
        _ui = GetComponent<BuildingUI>();
    }
    public void Start()
    {
        //HandleCollector(ref collector);
        Resource[] resources = _ui.FillResourcesInDictionary();

        BuildingManager.Register(_building, resources);
        
        for (int i = 0; i < resources.Length; i++)
        {
            _building.RegisterResource(resources[i].type, resources[i].amount);
        }
    }
}