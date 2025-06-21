using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MenuState : IState
{
    private Camera mCam;
    private MenuUI _UI;

    public void OnEnterState()
    {
        _UI = GameManager.Instance._UI.GetUI<MenuUI>();

        mCam = Camera.main;
        mCam.transform.position = new Vector3(mCam.transform.position.x, mCam.transform.position.y, _UI.initialCamPosZ);
 
        _UI.SetStartButton(StartButtonClick);
        _UI.ShowContainer();
    }

    public void OnUpdateState()
    {

    }

    public void OnExitState()
    {
        _UI.HideContainer();
    }

    private void StartButtonClick() 
    {
        _UI.m_StartButton.onClick.RemoveListener(StartButtonClick);
        _UI.MenuAnim(mCam.transform, ()=> GameManager.Instance.NextState());
    }
}
