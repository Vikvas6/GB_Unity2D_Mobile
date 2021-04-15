using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    private List<BaseController> _baseControllers;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;
    
    public void Dispose()
    {
        if (!_isDisposed)
        {
            _isDisposed = true;
            if (_baseControllers != null)
            {
                foreach (BaseController baseController in _baseControllers)
                {
                    baseController?.Dispose();
                }
                _baseControllers.Clear();
            }

            if (_gameObjects != null)
            {
                foreach (GameObject cachedGameObject in _gameObjects)
                {
                    Object.Destroy(cachedGameObject);
                }
                _gameObjects.Clear();
            }
            
            OnDispose();
        }
    }

    protected void AddController(BaseController baseController)
    {
        _baseControllers ??= new List<BaseController>();
        _baseControllers.Add(baseController);
    }

    protected void AddGameObjects(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }

    protected virtual void OnDispose()
    {
        
    }
}
