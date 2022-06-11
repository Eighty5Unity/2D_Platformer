using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private AllGameObjects _gameObjects;
    private Controllers _controllers;

    private void Awake()
    {
        _controllers = new Controllers();
        _controllers.Awake();
    }

    private void Start()
    {
        new GameInitialize(_controllers, _gameObjects);
        _controllers.Start();
    }

    private void Update()
    {
        var deltaTime = Time.deltaTime;
        _controllers.Update(deltaTime);
    }

    private void FixedUpdate()
    {
        var fixedDeltaTime = Time.fixedDeltaTime;
        _controllers.FixedUpdate(fixedDeltaTime);
    }

    private void LateUpdate()
    {
        var deltaTime = Time.deltaTime;
        _controllers.LateUpdate(deltaTime);
    }

    private void OnDestroy()
    {
        _controllers.OnDestroy();
    }
}
