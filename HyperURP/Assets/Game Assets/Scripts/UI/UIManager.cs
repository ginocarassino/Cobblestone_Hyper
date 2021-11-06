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
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    #region [LEVELS PANEL]
    public void LevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(2300,0), 0.25f);
        levelsMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseLevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        levelsMenu.DOAnchorPos(new Vector2(2300, 0), 0.25f);
    }
    #endregion

    #region [SHOP PANEL]
    public void ShopButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, -1120), 0.25f);
        shopMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseShopButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        shopMenu.DOAnchorPos(new Vector2(0, -1120), 0.25f);
    }
    #endregion

    #region [SETTINGS PANEL]
    public void SettingsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 1120), 0.25f);
        settingsMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
    public void CloseSettingsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.25f);
        settingsMenu.DOAnchorPos(new Vector2(0, 1120), 0.25f);
    }
    #endregion
}
