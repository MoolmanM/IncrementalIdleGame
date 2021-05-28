using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public enum CraftingType
{
    //I could maybe have different types here such as tools and then like refined crafting? For now it'll just be the name of each crafting option
    WoodenHoe,
    WoodenAxe,
    WoodenPickaxe,
    StoneHoe,
    StoneAxe,
    StonePickaxe
}

public abstract class Craftable : MonoBehaviour
{
    public static Dictionary<CraftingType, Craftable> Craftables = new Dictionary<CraftingType, Craftable>();

    public static bool isUnlockedEvent;
    public CraftingType Type;
    public ResourceCost[] resourceCost;
    public GameObject objSpacerBelow;
    [System.NonSerialized] public int isCrafted = 0;
    [System.NonSerialized] public int isUnlocked = 0;
    [System.NonSerialized] public GameObject objMainPanel;
    public float averageAmount;

    private string _isCraftedString, _isUnlockedString;

    protected BuildingType[] _buildingTypesToModify;
    protected ResourceType[] _resourceTypesToModify;
    protected WorkerType[] _workerTypesToModify;
    protected float _timer = 0.1f;
    protected readonly float _maxValue = 0.1f;
    protected TMP_Text _txtDescription;
    protected Transform _tformDescription, _tformTxtHeader, _tformBtnMain, _tformObjProgressCircle, _tformProgressbarPanel, _tformTxtHeaderUncraft, _tformBtnExpand, _tformBtnCollapse, _tformBody, _tformObjMain, _tformExpand, _tformCollapse;      
    protected Image _imgProgressbar, _imgMain, _imgExpand, _imgCollapse;
    protected GameObject _objProgressCircle, _objBtnMain, _objTxtHeader, _objTxtHeaderUncraft, _objBtnExpand, _objBtnCollapse, _objBody;

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_isCraftedString, isCrafted);
        PlayerPrefs.SetInt(_isUnlockedString, isUnlocked);
    }
    public void SetInitialValues()
    {
        InitializeObjects();
   
        if (TimeManager.hasPlayedBefore)
        {
            isUnlocked = PlayerPrefs.GetInt(_isUnlockedString, isUnlocked);
            isCrafted = PlayerPrefs.GetInt(_isCraftedString, isCrafted);
        }
        else
        {
            isCrafted = 0;
        }
        

        if (isCrafted == 1)
        {
            Crafted();
        }
        else
        {
            MakeCraftableAgain();
        }
    }
    protected void CheckIfUnlocked()
    {
        if (GetCurrentFill() == 1f)
        {
            Purchaseable();
        }
        else
        {
            UnPurchaseable();
        }

        if (isUnlocked == 0)
        {
            if (GetCurrentFill() >= 0.8f)
            {
                isUnlocked = 1;
                if(UIManager.isCraftingVisible)
                {
                    objMainPanel.SetActive(true);
                    objSpacerBelow.SetActive(true);
                }
                else
                {
                    isUnlockedEvent = true;                    
                }
            }
        }
    }
    public virtual void UpdateResourceCosts()
    {
        if ((_timer -= Time.deltaTime) <= 0)
        {
            _timer = _maxValue;

            for (int i = 0; i < resourceCost.Length; i++)
            {
                Craftables[Type].resourceCost[i].currentAmount = Resource.Resources[Craftables[Type].resourceCost[i].associatedType].amount;
                Craftables[Type].resourceCost[i].uiForResourceCost.textCostAmount.text = string.Format("{0:0.00}/{1:0.00}", Craftables[Type].resourceCost[i].currentAmount, Craftables[Type].resourceCost[i].costAmount);
                Craftables[Type].resourceCost[i].uiForResourceCost.textCostName.text = string.Format("{0}", Craftables[Type].resourceCost[i].associatedType.ToString());              
            }
            _imgProgressbar.fillAmount =  GetCurrentFill();
            CheckIfUnlocked();
        }
    }
    public void OnCraft()
    {
        bool canPurchase = true;

        for (int i = 0; i < resourceCost.Length; i++)
        {
            if (resourceCost[i].currentAmount < resourceCost[i].costAmount)
            {
                canPurchase = false;
                break;
            }
        }

        if (canPurchase)
        {
            isCrafted = 1;
            Crafted();
            UnlockBuilding();
            UnlockResource();
            for (int i = 0; i < resourceCost.Length; i++)
            {
                Resource.Resources[resourceCost[i].associatedType].amount -= resourceCost[i].costAmount;
            }

        }
    }
    protected virtual void Crafted()
    {
        _objBtnMain.GetComponent<Button>().interactable = false;
        _objProgressCircle.SetActive(false);
        _objTxtHeader.SetActive(false);
        _objTxtHeaderUncraft.SetActive(true);

        string htmlValue = "#D4D4D4";

        if (ColorUtility.TryParseHtmlString(htmlValue, out Color greyColor))
        {
            _imgExpand.color = greyColor;
            _imgCollapse.color = greyColor;
        }       
    }
    private void MakeCraftableAgain()
    {
        _objBtnMain.GetComponent<Button>().interactable = true;
        _objProgressCircle.SetActive(true);
        _objTxtHeader.SetActive(true);
        _objTxtHeaderUncraft.SetActive(false);

        string htmlValue = "#333333";

        if (ColorUtility.TryParseHtmlString(htmlValue, out Color darkGreyColor))
        {
            _imgExpand.color = darkGreyColor;
            _imgCollapse.color = darkGreyColor;
        }
    }
    protected virtual void UnlockBuilding()
    {
        foreach (var building in _buildingTypesToModify)
        {
            Building.Buildings[building].isUnlocked = 1;
            Building.isUnlockedEvent = true;
        }
    }
    protected virtual void UnlockResource()
    {
        foreach (var resource in _resourceTypesToModify)
        {
            Resource.Resources[resource].isUnlocked = 1;
            Resource.Resources[resource].objMainPanel.SetActive(true);
            Resource.Resources[resource].objSpacerBelow.SetActive(true);
        }
    }
    private void InitializeObjects()
    {
        _tformDescription = transform.Find("Panel_Main/Body/Text_Description");
        _tformTxtHeader = transform.Find("Panel_Main/Header_Panel/Text_Header");
        _tformBtnMain = transform.Find("Panel_Main/Header_Panel/Button_Main");
        _tformObjProgressCircle = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel/ProgressCircle");
        _tformProgressbarPanel = transform.Find("Panel_Main/Header_Panel/Progress_Circle_Panel");
        _tformTxtHeaderUncraft = transform.Find("Panel_Main/Header_Panel/Text_Header_Uncraftable");
        _tformBtnCollapse = transform.Find("Panel_Main/Header_Panel/Button_Collapse");
        _tformBtnExpand = transform.Find("Panel_Main/Header_Panel/Button_Expand");
        _tformBody = transform.Find("Panel_Main/Body");
        _tformObjMain = transform.Find("Panel_Main");

        _txtDescription = _tformDescription.GetComponent<TMP_Text>();
        _objTxtHeader = _tformTxtHeader.gameObject;
        _objBtnMain = _tformBtnMain.gameObject;
        _imgProgressbar = _tformObjProgressCircle.GetComponent<Image>();
        _objProgressCircle = _tformProgressbarPanel.gameObject;
        _objTxtHeaderUncraft = _tformTxtHeaderUncraft.gameObject;
        _imgExpand = _tformBtnExpand.GetComponent<Image>();
        _imgCollapse = _tformBtnCollapse.GetComponent<Image>();
        objMainPanel = _tformObjMain.gameObject;
        _objBtnExpand = _tformBtnExpand.gameObject;
        _objBtnCollapse = _tformBtnCollapse.gameObject;
        _objBody = _tformBody.gameObject;

        _isCraftedString = Type.ToString() + "isCrafted";
        _isUnlockedString = (Type.ToString() + "isUnlocked");


    }
    private void Purchaseable()
    {
        ColorBlock cb = _objBtnMain.GetComponent<Button>().colors;
        cb.normalColor = new Color(0, 0, 0, 0);
        _objBtnMain.GetComponent<Button>().colors = cb;
        string htmlValue = "#333333";

        if (ColorUtility.TryParseHtmlString(htmlValue, out Color darkGreyColor))
        {
            _objTxtHeader.GetComponent<TMP_Text>().color = darkGreyColor;
        }
    }
    private void UnPurchaseable()
    {
        ColorBlock cb = _objBtnMain.GetComponent<Button>().colors;
        cb.normalColor = new Color(0, 0, 0, 0.25f);
        cb.highlightedColor = new Color(0, 0, 0, 0.23f);
        cb.pressedColor = new Color(0, 0, 0, 0.3f);
        cb.selectedColor = new Color(0, 0, 0, 0.23f);
        _objBtnMain.GetComponent<Button>().colors = cb;

        string htmlValue = "#D71C2A";

        if (ColorUtility.TryParseHtmlString(htmlValue, out Color redColor))
        {
            _objTxtHeader.GetComponent<TMP_Text>().color = redColor;
        }
    }
    public float GetCurrentFill()
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
    public void OnExpandCloseAll()
    {
        foreach (var obj in Craftables)
        {
            obj.Value._objBody.SetActive(false);
            obj.Value._objBtnCollapse.SetActive(false);
            obj.Value._objBtnExpand.SetActive(true);
        }
        _objBtnExpand.SetActive(false);
        _objBody.SetActive(true);
        _objBtnCollapse.SetActive(true);

    }
    public void SetDescriptionText(string description)
    {
        Craftables[Type]._txtDescription.text = string.Format("{0}", description);
    }
}
