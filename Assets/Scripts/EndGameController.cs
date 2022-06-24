using UnityEngine;

public class EndGameController : IUpdate
{
    private GameTask _gameTask;

    public EndGameController(GameTask gameTask)
    {
        _gameTask = gameTask;
    }
    public void Update(float deltaTime)
    {
        if(_gameTask.TaskForWoman && _gameTask.TaskForBearded && _gameTask.TaskForHatman && _gameTask.TaskForOldman)
        {
            Debug.Log("FINISH!");
        }
    }
}
