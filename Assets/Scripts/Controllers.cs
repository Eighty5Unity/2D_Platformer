using System.Collections.Generic;
using UnityEngine;

internal sealed class Controllers : IAwake, IStart, IUpdate, IFixedUpdate, ILateUpdate, IOnDestroy
{
    private readonly List<IAwake> _awakeControllers;
    private readonly List<IStart> _startControllers;
    private readonly List<IUpdate> _updateControllers;
    private readonly List<IFixedUpdate> _fixedUpdateControllers;
    private readonly List<ILateUpdate> _lateUpdateControlles;
    private readonly List<IOnDestroy> _onDestroyControllers;

    internal Controllers()
    {
        _awakeControllers = new List<IAwake>();
        _startControllers = new List<IStart>();
        _updateControllers = new List<IUpdate>();
        _fixedUpdateControllers = new List<IFixedUpdate>();
        _lateUpdateControlles = new List<ILateUpdate>();
        _onDestroyControllers = new List<IOnDestroy>();
    }

    internal Controllers AddController(IController controller)
    {
        if (controller is IAwake awakeController)
        {
            _awakeControllers.Add(awakeController);
        }

        if (controller is IStart startController)
        {
            _startControllers.Add(startController);
        }

        if(controller is IUpdate updateController)
        {
            _updateControllers.Add(updateController);
        }

        if(controller is IFixedUpdate fixedUpdateController)
        {
            _fixedUpdateControllers.Add(fixedUpdateController);
        }

        if(controller is ILateUpdate lateUpdateController)
        {
            _lateUpdateControlles.Add(lateUpdateController);
        }

        if(controller is IOnDestroy onDestroyController)
        {
            _onDestroyControllers.Add(onDestroyController);
        }
        return this;
    }

    public void Awake()
    {
        foreach(var controller in _awakeControllers)
        {
            controller.Awake();
        }
    }

    public void Start()
    {
        foreach(var controller in _startControllers)
        {
            controller.Start();
        }
    }

    public void Update(float deltaTime)
    {
        foreach(var controller in _updateControllers)
        {
            controller.Update(deltaTime);
        }
    }

    public void FixedUpdate(float fixedDeltaTime)
    {
        foreach(var controller in _fixedUpdateControllers)
        {
            controller.FixedUpdate(fixedDeltaTime);
        }
    }

    public void LateUpdate(float deltaTime)
    {
        foreach(var controller in _lateUpdateControlles)
        {
            controller.LateUpdate(deltaTime);
        }
    }

    public void OnDestroy()
    {
        foreach(var controller in _onDestroyControllers)
        {
            controller.OnDestroy();
        }
    }
}
