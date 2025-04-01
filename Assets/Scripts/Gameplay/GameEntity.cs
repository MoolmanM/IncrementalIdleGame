using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct UiForResourceCost
{
  public TMP_Text CostNameText;
  public TMP_Text CostAmountText;

  public UiForResourceCost(TMP_Text costNameText, TMP_Text costAmountText)
  {
    CostNameText = costNameText;
    CostAmountText = costAmountText;
  }
}

[System.Serializable]
public struct ResourceCost
{
  public ResourceType AssociatedType;
  public float CostAmount;
  public float BaseCostAmount;
  public UiForResourceCost UiForResourceCost;

  // // Keeping track of CurrentAmount might be handled by another method or class
  [NonSerialized]
  public float CurrentAmount;

  public ResourceCost(ResourceType associatedType, float costAmount, float baseCostAmount, UiForResourceCost uiForResourceCost)
  {
    AssociatedType = associatedType;
    CostAmount = costAmount;
    BaseCostAmount = baseCostAmount;
    UiForResourceCost = uiForResourceCost;
    CurrentAmount = 0;
  }
  public ResourceType associatedType;
  [System.NonSerialized] public float currentAmount;
  public float costAmount;
  public float baseCostAmount;
  public UiForResourceCost uiForResourceCost;
}

[System.Serializable]
public struct TypesToUnlock
{
  // Arrays hold the unlockable types for various categories
  public ResourceType[] ResourceTypesToUnlock;
  public BuildingType[] BuildingTypesToUnlock;
  public ResearchType[] ResearchTypesToUnlock;
  public CraftingType[] CraftingTypesToUnlock;
  public WorkerType[] WorkerTypesToUnlock;

  // Flags to track which category is being unlocked
  public bool IsUnlockingResource;
  public bool IsUnlockingResearch;
  public bool IsUnlockingCrafting;
  public bool IsUnlockingBuilding;
  public bool IsUnlockingWorker;

  public TypesToUnlock(
      ResourceType[] resourceTypesToUnlock, BuildingType[] buildingTypesToUnlock,
      ResearchType[] researchTypesToUnlock, CraftingType[] craftingTypesToUnlock,
      WorkerType[] workerTypesToUnlock, bool isUnlockingResource, bool isUnlockingResearch,
      bool isUnlockingCrafting, bool isUnlockingBuilding, bool isUnlockingWorker)
  {
    ResourceTypesToUnlock = resourceTypesToUnlock;
    BuildingTypesToUnlock = buildingTypesToUnlock;
    ResearchTypesToUnlock = researchTypesToUnlock;
    CraftingTypesToUnlock = craftingTypesToUnlock;
    WorkerTypesToUnlock = workerTypesToUnlock;
    IsUnlockingResource = isUnlockingResource;
    IsUnlockingResearch = isUnlockingResearch;
    IsUnlockingCrafting = isUnlockingCrafting;
    IsUnlockingBuilding = isUnlockingBuilding;
    IsUnlockingWorker = isUnlockingWorker;
  }
=======
  public ResourceType[] resourceTypesToUnlock;
  public BuildingType[] buildingTypesToUnlock;
  public ResearchType[] researchTypesToUnlock;
  public CraftingType[] craftingTypesToUnlock;
  public WorkerType[] workerTypesToUnlock;
  public bool isUnlockingResource, isUnlockingResearch, isUnlockingCrafting, isUnlockingBuilding, isUnlockingWorker;
>>>>>>> c9b61117 (style: remove unnecessary comment)
}

public abstract class GameEntity : MonoBehaviour
{
<<<<<<< HEAD
  // Public fields (Pascal case)
  public GameObject PrefabResourceCost;
  public GameObject PrefabBodySpacer;
  public GameObject ObjBackground;
  public GameObject ObjProgressCircle;
  public GameObject ObjProgressCirclePanel;
  public GameObject ObjBtnMain;
  public GameObject ObjTxtHeader;
  public GameObject ObjBtnExpand;
  public GameObject ObjBtnCollapse;
  public GameObject ObjBody;

  public TMP_Text TxtDescription;
  public TMP_Text TxtHeader;

  public Transform TformDescription;
  public Transform TformObjBackground;
  public Transform TformTxtHeader;
  public Transform TformBtnMain;
  public Transform TformObjProgressCircle;
  public Transform TformProgressCirclePanel;
  public Transform TformBtnExpand;
  public Transform TformBtnCollapse;
  public Transform TformBody;
  public Transform TformObjMain;
  public Transform TformExpand;
  public Transform TformCollapse;

  public Image ImgMain;
  public Image ImgExpand;
  public Image ImgCollapse;
  public Image ImgProgressCircle;

  public Button BtnMain;

  public Color ColTxtHeader;

  private bool IsPurchaseableSet;
  private float currentFillCache;
  private string strCachedResourceCost;

  protected float timer = 0.1f;
  protected readonly float maxValue = 0.1f;
  protected float lastFillAmount;

  public ResourceCost[] ResourceCost;
  public TypesToUnlock TypesToUnlock;
  public bool IsUnlockableByResource;
  public int UnlockAmount, UnlocksRequired;
  public string ActualName;

  [NonSerialized] public bool IsUnlocked, IsFirstUnlocked, HasSeen = true, IsUnlockedByResource, IsPurchaseable;
  [NonSerialized] public GameObject ObjMainPanel;
  [NonSerialized] public Canvas Canvas;
  [NonSerialized] public GraphicRaycaster GraphicRaycaster;

=======
  public ResourceCost[] resourceCost;
  public TypesToUnlock typesToUnlock;
  public bool isUnlockableByResource;
  public int unlockAmount, unlocksRequired;
  public string actualName;

  [NonSerialized] public bool isUnlocked, isFirstUnlocked, hasSeen = true, isUnlockedByResource, isPurchaseable;
  [NonSerialized] public GameObject objMainPanel;
  [NonSerialized] public Canvas canvas;
  [NonSerialized] public GraphicRaycaster graphicRaycaster;

  // Implemnt method to consolidate UnlockResource, UnlockWorkerJob,
  // UnlockCrafting, UnlockBuilding, and UnlockResearchable into a generic unlock handler
  // based on the type of the entity

  protected float _timer = 0.1f, _lastFillAmount;
  protected readonly float _maxValue = 0.1f;
  protected GameObject _prefabResourceCost, _prefabBodySpacer, _objBackground, _objProgressCircle, _objProgressCirclePanel, _objBtnMain, _objTxtHeader, _objBtnExpand, _objBtnCollapse, _objBody;
  protected TMP_Text _txtDescription, _txtHeader;
  protected Transform _tformDescription, _tformObjBackground, _tformTxtHeader, _tformBtnMain, _tformObjProgressCircle, _tformProgressCirclePanel, _tformBtnExpand, _tformBtnCollapse, _tformBody, _tformObjMain, _tformExpand, _tformCollapse;
  protected Image _imgMain, _imgExpand, _imgCollapse, _imgProgressCircle;
  protected Button _btnMain;
  protected Color _colTxtHeader;
  protected bool _isPurchaseableSet;

  private float currentFillCache;

  private string _strCachedResourceCost;
>>>>>>> c9b61117 (style: remove unnecessary comment)

  private void OnValidate()
  {
    if (typesToUnlock.buildingTypesToUnlock.Length != 0)
    {
<<<<<<< HEAD
      if (TypesToUnlock.BuildingTypesToUnlock.Length != 0)
      {
        TypesToUnlock.IsUnlockingBuilding = true;
      }
      else
      {
        TypesToUnlock.IsUnlockingBuilding = false;
      }

      if (TypesToUnlock.CraftingTypesToUnlock.Length != 0)
      {
        TypesToUnlock.IsUnlockingCrafting = true;
      }
      else
      {
        TypesToUnlock.IsUnlockingCrafting = false;
      }

      if (TypesToUnlock.ResearchTypesToUnlock.Length != 0)
      {
        TypesToUnlock.IsUnlockingResearch = true;
      }
      else
      {
        TypesToUnlock.IsUnlockingResearch = false;
      }

      if (TypesToUnlock.WorkerTypesToUnlock.Length != 0)
      {
        TypesToUnlock.IsUnlockingWorker = true;
      }
      else
      {
        TypesToUnlock.IsUnlockingWorker = false;
      }

      if (TypesToUnlock.ResourceTypesToUnlock.Length != 0)
      {
        TypesToUnlock.IsUnlockingResource = true;
      }
      else
      {
        TypesToUnlock.IsUnlockingResource = false;
      }
=======
      typesToUnlock.isUnlockingBuilding = true;
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }
    else
    {
<<<<<<< HEAD
      TformBody = transform.Find("Panel_Main/Body");

      #region Prefab Initializion

      PrefabResourceCost = Resources.Load<GameObject>("ResourceCost_Prefab/ResourceCost_Panel");
      PrefabBodySpacer = Resources.Load<GameObject>("ResourceCost_Prefab/Body_Spacer");

      for (int i = 0; i < ResourceCost.Length; i++)
      {
        GameObject newObj = Instantiate(PrefabResourceCost, TformBody);

        if (i < ResourceCost.Length - 1)
        {
          Instantiate(PrefabBodySpacer, TformBody);
        }

        Transform _tformNewObj = newObj.transform;
        Transform _tformCostName = _tformNewObj.Find("Cost_Name_Panel/Text_CostName");
        Transform _tformCostAmount = _tformNewObj.Find("Cost_Amount_Panel/Text_CostAmount");

        ResourceCost[i].UiForResourceCost.CostNameText = _tformCostName.GetComponent<TMP_Text>();
        ResourceCost[i].UiForResourceCost.CostAmountText = _tformCostAmount.GetComponent<TMP_Text>();
      }

      #endregion


      GraphicRaycaster = gameObject.GetComponent<GraphicRaycaster>();
      Canvas = gameObject.GetComponent<Canvas>();

      TformObjBackground = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel/Background");
      TformDescription = transform.Find("Panel_Main/Body/Text_Description");
      TformTxtHeader = transform.Find("Panel_Main/Header_Panel/Text_Header");
      TformBtnMain = transform.Find("Panel_Main/Header_Panel/Button_Main");
      TformObjProgressCircle = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel/ProgressCircle");
      TformProgressCirclePanel = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel");
      TformBtnCollapse = transform.Find("Panel_Main/Header_Panel/Button_Collapse");
      TformBtnExpand = transform.Find("Panel_Main/Header_Panel/Button_Expand");
      TformObjMain = transform.Find("Panel_Main");


      ObjBackground = TformObjBackground.gameObject;
      ObjMainPanel = TformObjMain.gameObject;
      TxtDescription = TformDescription.GetComponent<TMP_Text>();
      ObjProgressCircle = TformObjProgressCircle.gameObject;
      ImgProgressCircle = TformObjProgressCircle.GetComponent<Image>();
      ImgExpand = TformBtnExpand.GetComponent<Image>();
      ImgCollapse = TformBtnCollapse.GetComponent<Image>();
      ObjProgressCirclePanel = TformProgressCirclePanel.gameObject;
      ObjTxtHeader = TformTxtHeader.gameObject;
      ObjBtnMain = TformBtnMain.gameObject;
      ObjBtnExpand = TformBtnExpand.gameObject;
      ObjBtnCollapse = TformBtnCollapse.gameObject;
      ObjBody = TformBody.gameObject;
      TxtHeader = ObjTxtHeader.GetComponent<TMP_Text>();
      BtnMain = ObjBtnMain.GetComponent<Button>();
      ColTxtHeader = ObjTxtHeader.GetComponent<TMP_Text>().color;

      ObjBtnExpand.GetComponent<Button>().onClick.AddListener(OnExpandCloseAll);
      ObjBtnCollapse.GetComponent<Button>().onClick.AddListener(OnCollapse);
    }
    protected void OnExpandCloseAll()
  {
    if (UIManager.isCraftingVisible)
    {
      foreach (var craft in Craftable.Craftables)
      {
        if (craft.Value.ObjBody.activeSelf)
        {
          craft.Value.ObjBody.SetActive(false);
          craft.Value.ObjBtnCollapse.SetActive(false);
          craft.Value.ObjBtnExpand.SetActive(true);
        }

      }
      ObjBtnExpand.SetActive(false);
      ObjBody.SetActive(true);
      ObjBtnCollapse.SetActive(true);
      LayoutRebuilder.ForceRebuildLayoutImmediate(ObjBody.GetComponent<RectTransform>());
=======
      typesToUnlock.isUnlockingBuilding = false;
    }

    if (typesToUnlock.craftingTypesToUnlock.Length != 0)
    {
      typesToUnlock.isUnlockingCrafting = true;
    }
    else
    {
      typesToUnlock.isUnlockingCrafting = false;
    }

    if (typesToUnlock.researchTypesToUnlock.Length != 0)
    {
      typesToUnlock.isUnlockingResearch = true;
    }
    else
    {
      typesToUnlock.isUnlockingResearch = false;
    }

    if (typesToUnlock.workerTypesToUnlock.Length != 0)
    {
      typesToUnlock.isUnlockingWorker = true;
    }
    else
    {
      typesToUnlock.isUnlockingWorker = false;
    }

    if (typesToUnlock.resourceTypesToUnlock.Length != 0)
    {
      typesToUnlock.isUnlockingResource = true;
    }
    else
    {
      typesToUnlock.isUnlockingResource = false;
    }
  }
  protected virtual void InitializeObjects()
  {
    _tformBody = transform.Find("Panel_Main/Body");

    #region Prefab Initializion

    _prefabResourceCost = Resources.Load<GameObject>("ResourceCost_Prefab/ResourceCost_Panel");
    _prefabBodySpacer = Resources.Load<GameObject>("ResourceCost_Prefab/Body_Spacer");

    for (int i = 0; i < resourceCost.Length; i++)
    {
      GameObject newObj = Instantiate(_prefabResourceCost, _tformBody);

      if (i < resourceCost.Length - 1)
      {
        Instantiate(_prefabBodySpacer, _tformBody);
      }

      Transform _tformNewObj = newObj.transform;
      Transform _tformCostName = _tformNewObj.Find("Cost_Name_Panel/Text_CostName");
      Transform _tformCostAmount = _tformNewObj.Find("Cost_Amount_Panel/Text_CostAmount");

      resourceCost[i].uiForResourceCost.CostNameText = _tformCostName.GetComponent<TMP_Text>();
      resourceCost[i].uiForResourceCost.CostAmountText = _tformCostAmount.GetComponent<TMP_Text>();
    }

    #endregion


    graphicRaycaster = gameObject.GetComponent<GraphicRaycaster>();
    canvas = gameObject.GetComponent<Canvas>();

    _tformObjBackground = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel/Background");
    _tformDescription = transform.Find("Panel_Main/Body/Text_Description");
    _tformTxtHeader = transform.Find("Panel_Main/Header_Panel/Text_Header");
    _tformBtnMain = transform.Find("Panel_Main/Header_Panel/Button_Main");
    _tformObjProgressCircle = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel/ProgressCircle");
    _tformProgressCirclePanel = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel");
    _tformBtnCollapse = transform.Find("Panel_Main/Header_Panel/Button_Collapse");
    _tformBtnExpand = transform.Find("Panel_Main/Header_Panel/Button_Expand");
    _tformObjMain = transform.Find("Panel_Main");


    _objBackground = _tformObjBackground.gameObject;
    objMainPanel = _tformObjMain.gameObject;
    _txtDescription = _tformDescription.GetComponent<TMP_Text>();
    _objProgressCircle = _tformObjProgressCircle.gameObject;
    _imgProgressCircle = _tformObjProgressCircle.GetComponent<Image>();
    _imgExpand = _tformBtnExpand.GetComponent<Image>();
    _imgCollapse = _tformBtnCollapse.GetComponent<Image>();
    _objProgressCirclePanel = _tformProgressCirclePanel.gameObject;
    _objTxtHeader = _tformTxtHeader.gameObject;
    _objBtnMain = _tformBtnMain.gameObject;
    _objBtnExpand = _tformBtnExpand.gameObject;
    _objBtnCollapse = _tformBtnCollapse.gameObject;
    _objBody = _tformBody.gameObject;
    _txtHeader = _objTxtHeader.GetComponent<TMP_Text>();
    _btnMain = _objBtnMain.GetComponent<Button>();
    _colTxtHeader = _objTxtHeader.GetComponent<TMP_Text>().color;

    _objBtnExpand.GetComponent<Button>().onClick.AddListener(OnExpandCloseAll);
    _objBtnCollapse.GetComponent<Button>().onClick.AddListener(OnCollapse);
  }
  protected void OnExpandCloseAll()
  {
    if (UIManager.isCraftingVisible)
    {
      foreach (var craft in Craftable.Craftables)
      {
        if (craft.Value._objBody.activeSelf)
        {
          craft.Value._objBody.SetActive(false);
          craft.Value._objBtnCollapse.SetActive(false);
          craft.Value._objBtnExpand.SetActive(true);
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }

  }
  _objBtnExpand.SetActive(false);
      _objBody.SetActive(true);
      _objBtnCollapse.SetActive(true);
      LayoutRebuilder.ForceRebuildLayoutImmediate(_objBody.GetComponent<RectTransform>());
    }

if (UIManager.isBuildingVisible)
{
  foreach (var building in Building.Buildings)
  {
    if (building.Value._objBody.activeSelf)
    {
      building.Value._objBody.SetActive(false);
      building.Value._objBtnCollapse.SetActive(false);
      building.Value._objBtnExpand.SetActive(true);
    }
  }
  _objBtnExpand.SetActive(false);
  _objBody.SetActive(true);
  _objBtnCollapse.SetActive(true);
  LayoutRebuilder.ForceRebuildLayoutImmediate(_objBody.GetComponent<RectTransform>());
}

if (UIManager.isResearchVisible)
{
  foreach (var research in Researchable.Researchables)
  {
    if (research.Value._objBody.activeSelf)
    {
      research.Value._objBody.SetActive(false);
      research.Value._objBtnCollapse.SetActive(false);
      research.Value._objBtnExpand.SetActive(true);
    }
  }
  _objBtnExpand.SetActive(false);
  _objBody.SetActive(true);
  _objBtnCollapse.SetActive(true);
  LayoutRebuilder.ForceRebuildLayoutImmediate(_objBody.GetComponent<RectTransform>());
}
  }
  protected void OnCollapse()
{
  _objBtnExpand.SetActive(true);
  _objBody.SetActive(false);
  _objBtnCollapse.SetActive(false);
}
protected void Purchaseable()
{
  string htmlValue = "#333333";

  _btnMain.interactable = true;

  if (ColorUtility.TryParseHtmlString(htmlValue, out Color darkGreyColor))
  {
    _colTxtHeader = darkGreyColor;
  }
}
protected void UnPurchaseable()
{
  _btnMain.interactable = false;

  string htmlValue = "#D71C2A";

  if (ColorUtility.TryParseHtmlString(htmlValue, out Color redColor))
  {
    _colTxtHeader = redColor;
  }
}
private void InitialBuildingUnlock(Building building)
{
  for (int i = 0; i < resourceCost.Length; i++)
  {
    //Resource.Resources[resourceCost[i].associatedType].amount -= resourceCost[i].costAmount;
    resourceCost[i].costAmount *= Mathf.Pow(building.costMultiplier, building._selfCount);
    resourceCost[i].uiForResourceCost.CostAmountText.text = string.Format("{0:0.00}/{1:0.00}", NumberToLetter.FormatNumber(Resource.Resources[resourceCost[i].associatedType].amount), NumberToLetter.FormatNumber(resourceCost[i].costAmount));
  }

  for (int i = 0; i < building.resourcesToIncrement.Count; i++)
  {
    if (CalculateAdBoost.isAdBoostActivated)
    {
      Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond += building.resourcesToIncrement[i].currentResourceMultiplier * building._selfCount * CalculateAdBoost.adBoostMultiplier;
    }
    else
    {
      Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond += building.resourcesToIncrement[i].currentResourceMultiplier * building._selfCount;
    }
    StaticMethods.ModifyAPSText(Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond, Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].uiForResource.txtAmountPerSecond);
  }
  building._txtHeader.text = string.Format("{0} ({1})", building.actualName, building._selfCount);
}
public virtual void CheckIfPurchaseable()
{
  if (isUnlocked)
  {
    if (_lastFillAmount != GetCurrentFill() && GetCurrentFill() != 1)
    {
      isPurchaseable = false;
      UnPurchaseable();
    }
    else if (GetCurrentFill() == 1)
    {
      isPurchaseable = true;
    }

    if (!isPurchaseable)
    {
      _isPurchaseableSet = false;
    }
    else if (isPurchaseable && !_isPurchaseableSet)
    {
      Purchaseable();
      _isPurchaseableSet = true;
    }

    _lastFillAmount = GetCurrentFill();
  }
}
protected void CalculateResourceCosts(TMP_Text txt, float current, float cost, float amountPerSecond, float storageAmount)
{
  string strResourceCost;
  if (amountPerSecond > 0 && cost > current)
  {
    float secondsLeft = (cost - current) / (amountPerSecond);
    TimeSpan timeSpan = TimeSpan.FromSeconds((double)(new decimal(secondsLeft)));

    if (storageAmount < cost)
    {
      strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#D71C2A>Never</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost));
    }
    else
    {
      if (current >= cost)
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost));
      }
      else if (timeSpan.Days == 0 && timeSpan.Hours == 0 && timeSpan.Minutes == 0 && timeSpan.Seconds < 1)
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#08F1FF>0.{2:%f}ms</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost), timeSpan.Duration());
      }
      else if (timeSpan.Days == 0 && timeSpan.Hours == 0 && timeSpan.Minutes == 0)
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#08F1FF>{2:%s}s</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost), timeSpan.Duration());
      }
      else if (timeSpan.Days == 0 && timeSpan.Hours == 0)
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#08F1FF>{2:%m}m{2:%s}s</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost), timeSpan.Duration());
      }
      else if (timeSpan.Days == 0)
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#08F1FF>{2:%h}h{2:%m}m</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost), timeSpan.Duration());
      }
      else
      {
        strResourceCost = string.Format("{0:0.00}/{1:0.00}(<color=#08F1FF>{2:%d}d{2:%h}h</color>)", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost), timeSpan.Duration());
      }
    }

  }
  else
  {
    strResourceCost = string.Format("{0:0.00}/{1:0.00}", NumberToLetter.FormatNumber(current), NumberToLetter.FormatNumber(cost));
  }

  if (strResourceCost != _strCachedResourceCost)
  {
    txt.text = strResourceCost;
  }
  _strCachedResourceCost = strResourceCost;
}
protected float GetCurrentFill()
{
  float add = 0;
  float div = 0;
  float fillAmount = 0;

  for (int i = 0; i < resourceCost.Length; i++)
  {
    add = resourceCost[i].currentAmount;
    div = resourceCost[i].costAmount;
    if (add > div)
    {
      add = div;
    }
    fillAmount += add / div;
  }
  return fillAmount / resourceCost.Length;
}
protected void CheckIfBuildingUnlocked()
{
  foreach (var building in Building.Buildings)
  {
    if (building.Value.isUnlocked)
    {
      InitialBuildingUnlock(building.Value);
      building.Value.objMainPanel.SetActive(true);

      if (UIManager.isBuildingVisible)
      {
<<<<<<< HEAD
        foreach (var building in Building.Buildings)
        {
          if (building.Value.ObjBody.activeSelf)
          {
            building.Value.ObjBody.SetActive(false);
            building.Value.ObjBtnCollapse.SetActive(false);
            building.Value.ObjBtnExpand.SetActive(true);
          }
        }
        ObjBtnExpand.SetActive(false);
        ObjBody.SetActive(true);
        ObjBtnCollapse.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(ObjBody.GetComponent<RectTransform>());
=======
          building.Value.canvas.enabled = true;
          building.Value.graphicRaycaster.enabled = true;
          building.Value.hasSeen = true;
>>>>>>> c9b61117 (style: remove unnecessary comment)
      }
      else if (building.Value.hasSeen)
      {
        Building.isBuildingUnlockedEvent = true;
        building.Value.hasSeen = false;
        PointerNotification.leftAmount++;
      }
    }
  }
}
protected void CheckIfCraftingUnlocked()
{
  foreach (var craftable in Craftable.Craftables)
  {
    if (craftable.Value.isUnlocked)
    {
      if (UIManager.isBuildingVisible && craftable.Value.hasSeen)
      {
        Craftable.isCraftableUnlockedEvent = true;
        craftable.Value.hasSeen = false;
        PointerNotification.rightAmount++;
      }
      else if (UIManager.isCraftingVisible)
      {
        // This does run more than once each, but isn't a big deal
        craftable.Value.objMainPanel.SetActive(true);
        craftable.Value.canvas.enabled = true;
        craftable.Value.graphicRaycaster.enabled = true;
        craftable.Value.hasSeen = true;
      }
      else if (UIManager.isWorkerVisible && craftable.Value.hasSeen)
      {
        Craftable.isCraftableUnlockedEvent = true;
        craftable.Value.hasSeen = false;
        PointerNotification.leftAmount++;
      }
      else if (UIManager.isResearchVisible && craftable.Value.hasSeen)
      {
        Craftable.isCraftableUnlockedEvent = true;
        craftable.Value.hasSeen = false;
        PointerNotification.leftAmount++;
      }
    }
  }
}
protected void CheckIfWorkerUnlocked()
{
  foreach (var worker in Worker.Workers)
  {
    if (worker.Value.isUnlocked)
    {
      worker.Value.objMainPanel.SetActive(true);

      if (UIManager.isBuildingVisible && worker.Value.hasSeen)
      {
        Worker.isWorkerUnlockedEvent = true;
        worker.Value.hasSeen = false;
        PointerNotification.rightAmount++;
      }
      else if (UIManager.isCraftingVisible && worker.Value.hasSeen)
      {
        Worker.isWorkerUnlockedEvent = true;
        worker.Value.hasSeen = false;
        PointerNotification.rightAmount++;
      }
      else if (UIManager.isWorkerVisible)
      {
        worker.Value.canvas.enabled = true;
        worker.Value.graphicRaycaster.enabled = true;
        worker.Value.hasSeen = true;
      }
      else if (UIManager.isResearchVisible && worker.Value.hasSeen)
      {
        Worker.isWorkerUnlockedEvent = true;
        worker.Value.hasSeen = false;
        PointerNotification.leftAmount++;
      }
    }
  }
}
protected void CheckIfResearchUnlocked()
{
  foreach (var researchable in Researchable.Researchables)
  {
    if (researchable.Value.isUnlocked)
    {
      if (UIManager.isResearchVisible)
      {
<<<<<<< HEAD
        foreach (var research in Researchable.Researchables)
        {
          if (research.Value.ObjBody.activeSelf)
          {
            research.Value.ObjBody.SetActive(false);
            research.Value.ObjBtnCollapse.SetActive(false);
            research.Value.ObjBtnExpand.SetActive(true);
          }
        }
        ObjBtnExpand.SetActive(false);
        ObjBody.SetActive(true);
        ObjBtnCollapse.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(ObjBody.GetComponent<RectTransform>());
      }
    }
    protected void OnCollapse()
{
  ObjBtnExpand.SetActive(true);
  ObjBody.SetActive(false);
  ObjBtnCollapse.SetActive(false);
}
protected void Purchaseable()
{
  string htmlValue = "#333333";

  BtnMain.interactable = true;

  if (ColorUtility.TryParseHtmlString(htmlValue, out Color darkGreyColor))
  {
    ColTxtHeader = darkGreyColor;
=======
          researchable.Value.objMainPanel.SetActive(true);
          researchable.Value.canvas.enabled = true;
          researchable.Value.graphicRaycaster.enabled = true;
          researchable.Value.hasSeen = true;
        }
        else if (researchable.Value.hasSeen)
        {
          Researchable.isResearchableUnlockedEvent = true;
          researchable.Value.hasSeen = false;
          PointerNotification.rightAmount++;
>>>>>>> c9b61117 (style: remove unnecessary comment)
  }
}
    }
  }
  protected void CheckIfUnlockedDeprecated()
{
  if (!isUnlocked)
  {
<<<<<<< HEAD
    BtnMain.interactable = false;

=======
      if (GetCurrentFill() >= 0.8f & !isUnlockedByResource && isUnlockableByResource)
      {
        isUnlockedByResource = true;
        unlockAmount++;
>>>>>>> c9b61117 (style: remove unnecessary comment)
    if (unlockAmount == unlocksRequired)
    {
<<<<<<< HEAD
      ColTxtHeader = redColor;
=======
          isUnlocked = true;
          if (typesToUnlock.isUnlockingResearch)
          {
            CheckIfResearchUnlocked();
          }
          if (typesToUnlock.isUnlockingCrafting)
          {
            CheckIfCraftingUnlocked();
          }
          if (typesToUnlock.isUnlockingWorker)
          {
            CheckIfWorkerUnlocked();
          }
          if (typesToUnlock.isUnlockingBuilding)
          {
            CheckIfBuildingUnlocked();
          }



          PointerNotification.HandleRightAnim();
          PointerNotification.HandleLeftAnim();
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }
  }
}
  }
  protected void UnlockResource()
{
  if (typesToUnlock.isUnlockingResource)
  {
<<<<<<< HEAD
    for (int i = 0; i < ResourceCost.Length; i++)
    {
      //Resource.Resources[ResourceCost[i].AssociatedType].amount -= ResourceCost[i].CostAmount;
      ResourceCost[i].CostAmount *= Mathf.Pow(building.costMultiplier, building._selfCount);
      ResourceCost[i].UiForResourceCost.CostAmountText.text = string.Format("{0:0.00}/{1:0.00}", NumberToLetter.FormatNumber(Resource.Resources[ResourceCost[i].AssociatedType].amount), NumberToLetter.FormatNumber(ResourceCost[i].CostAmount));
    }

    for (int i = 0; i < building.resourcesToIncrement.Count; i++)
    {
      if (CalculateAdBoost.isAdBoostActivated)
      {
        Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond += building.resourcesToIncrement[i].currentResourceMultiplier * building._selfCount * CalculateAdBoost.adBoostMultiplier;
      }
      else
      {
        Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond += building.resourcesToIncrement[i].currentResourceMultiplier * building._selfCount;
      }
      StaticMethods.ModifyAPSText(Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].amountPerSecond, Resource.Resources[building.resourcesToIncrement[i].resourceTypeToModify].uiForResource.txtAmountPerSecond);
    }
    building.TxtHeader.text = string.Format("{0} ({1})", building.ActualName, building._selfCount);

    //building.UpdateResourceInfo();
=======
      foreach (var resource in typesToUnlock.resourceTypesToUnlock)
      {
        Resource.Resources[resource].InitializeAmount();
        Resource.Resources[resource].isUnlocked = true;
        Resource.Resources[resource].objMainPanel.SetActive(true);
        Resource.Resources[resource].canvas.enabled = true;
        Resource.Resources[resource].graphicRaycaster.enabled = true;
      }
>>>>>>> c9b61117 (style: remove unnecessary comment)
  }
}
protected void UnlockWorkerJob()
{
  if (typesToUnlock.isUnlockingWorker)
  {
<<<<<<< HEAD
    if (IsUnlocked)
    {
      if (lastFillAmount != GetCurrentFill() && GetCurrentFill() != 1)
      {
        IsPurchaseable = false;
        UnPurchaseable();
      }
      else if (GetCurrentFill() == 1)
      {
        IsPurchaseable = true;
      }

      if (!IsPurchaseable)
      {
        IsPurchaseableSet = false;
      }
      else if (IsPurchaseable && !IsPurchaseableSet)
      {
        Purchaseable();
        IsPurchaseableSet = true;
      }

      lastFillAmount = GetCurrentFill();
=======
      foreach (var worker in typesToUnlock.workerTypesToUnlock)
      {
        Worker.Workers[worker].isUnlocked = true;
        Worker.Workers[worker].objMainPanel.SetActive(true);

        if (UIManager.isWorkerVisible)
        {
          Worker.Workers[worker].canvas.enabled = true;
          Worker.Workers[worker].graphicRaycaster.enabled = true;
          Worker.Workers[worker].hasSeen = true;
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }
    else if (UIManager.isResearchVisible)
    {
      Worker.isWorkerUnlockedEvent = true;
      Worker.Workers[worker].hasSeen = false;
      PointerNotification.leftAmount++;
      PointerNotification.HandleLeftAnim();
    }
    else
    {
      Worker.isWorkerUnlockedEvent = true;
      Worker.Workers[worker].hasSeen = false;
      PointerNotification.rightAmount++;
      PointerNotification.HandleRightAnim();
    }

<<<<<<< HEAD
    if (strResourceCost != strCachedResourceCost)
=======
        AutoWorker.TotalWorkerJobs++;

        if (AutoToggle.isAutoWorkerOn == 1)
>>>>>>> c9b61117 (style: remove unnecessary comment)
    {
      AutoWorker.CalculateWorkers();
      AutoWorker.AutoAssignWorkers();
    }
<<<<<<< HEAD
    strCachedResourceCost = strResourceCost;
=======
      }
>>>>>>> c9b61117 (style: remove unnecessary comment)
  }
}
protected void UnlockCrafting()
{
  if (typesToUnlock.isUnlockingCrafting)
  {
    foreach (CraftingType craft in typesToUnlock.craftingTypesToUnlock)
    {
      Craftable.Craftables[craft].unlockAmount++;

<<<<<<< HEAD
      for (int i = 0; i < ResourceCost.Length; i++)
      {
        add = ResourceCost[i].CurrentAmount;
        div = ResourceCost[i].CostAmount;
        if (add > div)
        {
          add = div;
        }
        fillAmount += add / div;
      }
      return fillAmount / ResourceCost.Length;
=======
        if (Craftable.Craftables[craft].unlockAmount == Craftable.Craftables[craft].unlocksRequired)
        {
          Craftable.Craftables[craft].isUnlocked = true;

          if (UIManager.isBuildingVisible)
          {
            Craftable.isCraftableUnlockedEvent = true;
            Craftable.Craftables[craft].hasSeen = false;
            PointerNotification.rightAmount++;
            PointerNotification.HandleRightAnim();
          }
          else if (!UIManager.isCraftingVisible)
          {
            Craftable.isCraftableUnlockedEvent = true;
            Craftable.Craftables[craft].hasSeen = false;
            PointerNotification.leftAmount++;
            PointerNotification.HandleLeftAnim();
          }
          else
          {
            Craftable.Craftables[craft].objMainPanel.SetActive(true);
            Craftable.Craftables[craft].canvas.enabled = true;
            Craftable.Craftables[craft].graphicRaycaster.enabled = true;
            Craftable.Craftables[craft].hasSeen = true;
          }
        }
      }
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }
  }
  protected void UnlockBuilding()
{
  if (typesToUnlock.isUnlockingBuilding)
  {
<<<<<<< HEAD
    foreach (var building in Building.Buildings)
    {
      if (building.Value.IsUnlocked)
      {
        InitialBuildingUnlock(building.Value);
        building.Value.ObjMainPanel.SetActive(true);

        if (UIManager.isBuildingVisible)
        {
          building.Value.Canvas.enabled = true;
          building.Value.GraphicRaycaster.enabled = true;
          building.Value.HasSeen = true;
        }
        else if (building.Value.HasSeen)
        {
          Building.isBuildingUnlockedEvent = true;
          building.Value.HasSeen = false;
          PointerNotification.leftAmount++;
        }
      }
=======
      foreach (BuildingType buildingType in typesToUnlock.buildingTypesToUnlock)
      {
        Building.Buildings[buildingType].unlockAmount++;
        Building.Buildings[buildingType].objMainPanel.SetActive(true);

        if (Building.Buildings[buildingType].unlockAmount == Building.Buildings[buildingType].unlocksRequired)
        {
          InitialBuildingUnlock(Building.Buildings[buildingType]);
          Building.Buildings[buildingType].isUnlocked = true;
          Building.Buildings[buildingType].CheckIfPurchaseable();

          if (!UIManager.isBuildingVisible)
          {
            Building.isBuildingUnlockedEvent = true;
            Building.Buildings[buildingType].hasSeen = false;
            PointerNotification.leftAmount++;
            PointerNotification.HandleLeftAnim();
          }
          else
          {
            Building.Buildings[buildingType].canvas.enabled = true;
            Building.Buildings[buildingType].graphicRaycaster.enabled = true;
            Building.Buildings[buildingType].hasSeen = true;
          }
>>>>>>> c9b61117 (style: remove unnecessary comment)
    }
  }
}
  }
  protected void UnlockResearchable()
{
  if (typesToUnlock.isUnlockingResearch)
  {
    foreach (ResearchType research in typesToUnlock.researchTypesToUnlock)
    {
      Researchable.Researchables[research].unlockAmount++;

      if (Researchable.Researchables[research].unlockAmount == Researchable.Researchables[research].unlocksRequired)
      {
<<<<<<< HEAD
        if (craftable.Value.IsUnlocked)
        {
          if (UIManager.isBuildingVisible && craftable.Value.HasSeen)
          {
            Craftable.isCraftableUnlockedEvent = true;
            craftable.Value.HasSeen = false;
            PointerNotification.rightAmount++;
          }
          else if (UIManager.isCraftingVisible)
          {
            // This does run more than once each, but isn't a big deal
            craftable.Value.ObjMainPanel.SetActive(true);
            craftable.Value.Canvas.enabled = true;
            craftable.Value.GraphicRaycaster.enabled = true;
            craftable.Value.HasSeen = true;
          }
          else if (UIManager.isWorkerVisible && craftable.Value.HasSeen)
          {
            Craftable.isCraftableUnlockedEvent = true;
            craftable.Value.HasSeen = false;
            PointerNotification.leftAmount++;
          }
          else if (UIManager.isResearchVisible && craftable.Value.HasSeen)
          {
            Craftable.isCraftableUnlockedEvent = true;
            craftable.Value.HasSeen = false;
            PointerNotification.leftAmount++;
          }
        }
=======
          Researchable.Researchables[research].isUnlocked = true;

          if (UIManager.isResearchVisible)
          {
            Researchable.Researchables[research].objMainPanel.SetActive(true);
            Researchable.Researchables[research].canvas.enabled = true;
            Researchable.Researchables[research].graphicRaycaster.enabled = true;
            Researchable.Researchables[research].hasSeen = true;
          }
          else
          {
            Researchable.isResearchableUnlockedEvent = true;
            Researchable.Researchables[research].hasSeen = false;
            PointerNotification.rightAmount++;
            PointerNotification.HandleRightAnim();
          }
>>>>>>> c9b61117 (style: remove unnecessary comment)
      }
    }
  }
}
protected void UpdateResourceCostTexts()
{
  for (int i = 0; i < resourceCost.Length; i++)
  {
<<<<<<< HEAD
    foreach (var worker in Worker.Workers)
    {
      if (worker.Value.IsUnlocked)
      {
        worker.Value.ObjMainPanel.SetActive(true);

        if (UIManager.isBuildingVisible && worker.Value.HasSeen)
        {
          Worker.isWorkerUnlockedEvent = true;
          worker.Value.HasSeen = false;
          PointerNotification.rightAmount++;
        }
        else if (UIManager.isCraftingVisible && worker.Value.HasSeen)
        {
          Worker.isWorkerUnlockedEvent = true;
          worker.Value.HasSeen = false;
          PointerNotification.rightAmount++;
        }
        else if (UIManager.isWorkerVisible)
        {
          worker.Value.Canvas.enabled = true;
          worker.Value.GraphicRaycaster.enabled = true;
          worker.Value.HasSeen = true;
        }
        else if (UIManager.isResearchVisible && worker.Value.HasSeen)
        {
          Worker.isWorkerUnlockedEvent = true;
          worker.Value.HasSeen = false;
          PointerNotification.leftAmount++;
        }
      }
    }
=======
      resourceCost[i].currentAmount = Resource.Resources[resourceCost[i].associatedType].amount;

      if (!_objBtnExpand.activeSelf && isUnlocked)
      {
        resourceCost[i].uiForResourceCost.CostNameText.text = string.Format("{0}", resourceCost[i].associatedType.ToString());
        CalculateResourceCosts(resourceCost[i].uiForResourceCost.CostAmountText, resourceCost[i].currentAmount, resourceCost[i].costAmount, Resource.Resources[resourceCost[i].associatedType].amountPerSecond, Resource.Resources[resourceCost[i].associatedType].storageAmount);
      }
>>>>>>> c9b61117 (style: remove unnecessary comment)
  }

  if (GetCurrentFill() != currentFillCache && isUnlocked)
  {
<<<<<<< HEAD
    foreach (var researchable in Researchable.Researchables)
    {
      if (researchable.Value.IsUnlocked)
      {
        if (UIManager.isResearchVisible)
        {
          researchable.Value.ObjMainPanel.SetActive(true);
          researchable.Value.Canvas.enabled = true;
          researchable.Value.GraphicRaycaster.enabled = true;
          researchable.Value.HasSeen = true;
        }
        else if (researchable.Value.HasSeen)
        {
          Researchable.isResearchableUnlockedEvent = true;
          researchable.Value.HasSeen = false;
          PointerNotification.rightAmount++;
        }
      }
    }
  }
    protected void CheckIfUnlockedDeprecated()
{
  if (!IsUnlocked)
  {
    if (GetCurrentFill() >= 0.8f & !IsUnlockedByResource && IsUnlockableByResource)
    {
      IsUnlockedByResource = true;
      UnlockAmount++;

      if (UnlockAmount == UnlocksRequired)
      {
        IsUnlocked = true;
        if (TypesToUnlock.IsUnlockingResearch)
        {
          CheckIfResearchUnlocked();
        }
        if (TypesToUnlock.IsUnlockingCrafting)
        {
          CheckIfCraftingUnlocked();
        }
        if (TypesToUnlock.IsUnlockingWorker)
        {
          CheckIfWorkerUnlocked();
        }
        if (TypesToUnlock.IsUnlockingBuilding)
        {
          CheckIfBuildingUnlocked();
        }



        PointerNotification.HandleRightAnim();
        PointerNotification.HandleLeftAnim();
      }
    }
  }
}
protected void UnlockResource()
{
  if (TypesToUnlock.IsUnlockingResource)
  {
    foreach (var resource in TypesToUnlock.ResourceTypesToUnlock)
    {
      Resource.Resources[resource].InitializeAmount();
      Resource.Resources[resource].IsUnlocked = true;
      Resource.Resources[resource].ObjMainPanel.SetActive(true);
      Resource.Resources[resource].Canvas.enabled = true;
      Resource.Resources[resource].GraphicRaycaster.enabled = true;
    }
  }
}
protected void UnlockWorkerJob()
{
  if (TypesToUnlock.IsUnlockingWorker)
  {
    foreach (var worker in TypesToUnlock.WorkerTypesToUnlock)
    {
      Worker.Workers[worker].IsUnlocked = true;
      Worker.Workers[worker].ObjMainPanel.SetActive(true);

      if (UIManager.isWorkerVisible)
      {
        Worker.Workers[worker].Canvas.enabled = true;
        Worker.Workers[worker].GraphicRaycaster.enabled = true;
        Worker.Workers[worker].HasSeen = true;
      }
      else if (UIManager.isResearchVisible)
      {
        Worker.isWorkerUnlockedEvent = true;
        Worker.Workers[worker].HasSeen = false;
        PointerNotification.leftAmount++;
        PointerNotification.HandleLeftAnim();
      }
      else
      {
        Worker.isWorkerUnlockedEvent = true;
        Worker.Workers[worker].HasSeen = false;
        PointerNotification.rightAmount++;
        PointerNotification.HandleRightAnim();
      }

      AutoWorker.TotalWorkerJobs++;

      if (AutoToggle.isAutoWorkerOn == 1)
      {
        AutoWorker.CalculateWorkers();
        AutoWorker.AutoAssignWorkers();
      }
    }
  }
}
protected void UnlockCrafting()
{
  if (TypesToUnlock.IsUnlockingCrafting)
  {
    foreach (CraftingType craft in TypesToUnlock.CraftingTypesToUnlock)
    {
      Craftable.Craftables[craft].UnlockAmount++;

      if (Craftable.Craftables[craft].UnlockAmount == Craftable.Craftables[craft].UnlocksRequired)
      {
        Craftable.Craftables[craft].IsUnlocked = true;

        if (UIManager.isBuildingVisible)
        {
          Craftable.isCraftableUnlockedEvent = true;
          Craftable.Craftables[craft].HasSeen = false;
          PointerNotification.rightAmount++;
          PointerNotification.HandleRightAnim();
        }
        else if (!UIManager.isCraftingVisible)
        {
          Craftable.isCraftableUnlockedEvent = true;
          Craftable.Craftables[craft].HasSeen = false;
          PointerNotification.leftAmount++;
          PointerNotification.HandleLeftAnim();
        }
        else
        {
          Craftable.Craftables[craft].ObjMainPanel.SetActive(true);
          Craftable.Craftables[craft].Canvas.enabled = true;
          Craftable.Craftables[craft].GraphicRaycaster.enabled = true;
          Craftable.Craftables[craft].HasSeen = true;
        }
      }
    }
  }
}
protected void UnlockBuilding()
{
  if (TypesToUnlock.IsUnlockingBuilding)
  {
    foreach (BuildingType buildingType in TypesToUnlock.BuildingTypesToUnlock)
    {
      Building.Buildings[buildingType].UnlockAmount++;
      Building.Buildings[buildingType].ObjMainPanel.SetActive(true);

      if (Building.Buildings[buildingType].UnlockAmount == Building.Buildings[buildingType].UnlocksRequired)
      {
        InitialBuildingUnlock(Building.Buildings[buildingType]);
        Building.Buildings[buildingType].IsUnlocked = true;
        Building.Buildings[buildingType].CheckIfPurchaseable();

        if (!UIManager.isBuildingVisible)
        {
          Building.isBuildingUnlockedEvent = true;
          Building.Buildings[buildingType].HasSeen = false;
          PointerNotification.leftAmount++;
          PointerNotification.HandleLeftAnim();
        }
        else
        {
          Building.Buildings[buildingType].Canvas.enabled = true;
          Building.Buildings[buildingType].GraphicRaycaster.enabled = true;
          Building.Buildings[buildingType].HasSeen = true;
        }
      }
    }
  }
}
protected void UnlockResearchable()
{
  if (TypesToUnlock.IsUnlockingResearch)
  {
    foreach (ResearchType research in TypesToUnlock.ResearchTypesToUnlock)
    {
      Researchable.Researchables[research].UnlockAmount++;

      if (Researchable.Researchables[research].UnlockAmount == Researchable.Researchables[research].UnlocksRequired)
      {
        Researchable.Researchables[research].IsUnlocked = true;

        if (UIManager.isResearchVisible)
        {
          Researchable.Researchables[research].ObjMainPanel.SetActive(true);
          Researchable.Researchables[research].Canvas.enabled = true;
          Researchable.Researchables[research].GraphicRaycaster.enabled = true;
          Researchable.Researchables[research].HasSeen = true;
        }
        else
        {
          Researchable.isResearchableUnlockedEvent = true;
          Researchable.Researchables[research].HasSeen = false;
          PointerNotification.rightAmount++;
          PointerNotification.HandleRightAnim();
        }
      }
    }
  }
}
protected void UpdateResourceCostTexts()
{
  for (int i = 0; i < ResourceCost.Length; i++)
  {
    ResourceCost[i].CurrentAmount = Resource.Resources[ResourceCost[i].AssociatedType].amount;

    if (!ObjBtnExpand.activeSelf && IsUnlocked)
    {
      ResourceCost[i].UiForResourceCost.CostNameText.text = string.Format("{0}", ResourceCost[i].AssociatedType.ToString());
      CalculateResourceCosts(ResourceCost[i].UiForResourceCost.CostAmountText, ResourceCost[i].CurrentAmount, ResourceCost[i].CostAmount, Resource.Resources[ResourceCost[i].AssociatedType].amountPerSecond, Resource.Resources[ResourceCost[i].AssociatedType].storageAmount);
    }
  }

  if (GetCurrentFill() != currentFillCache && IsUnlocked)
  {
    ImgProgressCircle.fillAmount = GetCurrentFill();
  }
  currentFillCache = GetCurrentFill();
=======
      _imgProgressCircle.fillAmount = GetCurrentFill();
>>>>>>> c9b61117 (style: remove unnecessary comment)
}
currentFillCache = GetCurrentFill();
  }
}
