using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelsMenu, shopMenu, settingsMenu;

    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.50f);
    }

    #region [LEVELS PANEL]
    public void LevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(2300,0), 0.50f);
        levelsMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
    }
    public void CloseLevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
        levelsMenu.DOAnchorPos(new Vector2(2300, 0), 0.50f);
    }
    #endregion

    #region [SHOP PANEL]
    public void ShopButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, -1120), 0.50f);
        shopMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
    }
    public void CloseShopButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
        shopMenu.DOAnchorPos(new Vector2(0, -1120), 0.50f);
    }
    #endregion

    #region [SETTINGS PANEL]
    public void SettingsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 1120), 0.50f);
        settingsMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
    }
    public void CloseSettingsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.50f);
        settingsMenu.DOAnchorPos(new Vector2(0, 1120), 0.50f);
    }
    #endregion
}
