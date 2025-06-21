using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class UIController : MonoBehaviour
{  
    public List<UIContainer> uIContainers = new List<UIContainer>();

    public UIContainer GetUI()
    {
        int index = GameManager.Instance.StateIndex;
        return uIContainers[index];
    }

    public T GetUI<T>() where T : UIContainer
    {
        UIContainer ui = uIContainers.First(ui => ui.GetType() == typeof(T));
        return (T)ui;
    }
}
