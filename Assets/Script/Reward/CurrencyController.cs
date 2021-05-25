using System.Collections;
using System.Collections.Generic;
using Game.Reward;
using Tools;
using UnityEngine;

public class CurrencyController : BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Currency Window"};
    private CurrencyView _currencyView;

    public CurrencyController(Transform placeForUi)
    {
        _currencyView = LoadView(placeForUi);
    }

    private CurrencyView LoadView(Transform placeForUi)
    {
        GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObjects(objectView);
        return objectView.GetComponent<CurrencyView>();
    }
}
