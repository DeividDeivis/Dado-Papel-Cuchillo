using UnityEngine;

public abstract class UIContainer : MonoBehaviour, IUIContainer
{
    public CanvasGroup _container;

    public virtual void SetContainer()
    {
        
    }

    public virtual void ShowContainer() 
    {
        _container.gameObject.SetActive(true);
    }

    public virtual void HideContainer()
    {
        _container.gameObject.SetActive(false);
    }  
}

public interface IUIContainer 
{
    public void SetContainer();
    public void ShowContainer();
    public void HideContainer();
}
