public class GameTask
{
    private bool _taskForWoman;

    private bool _taskForHatman;
    private bool _taskForHatmanJumpIntoWell;

    private bool _taskForOldman;
    private bool _taskForOldmanGetStaff;

    private bool _taskForBearded;
    private bool _taskForBeardedFillWagon;

    public bool TaskForWoman { get => _taskForWoman; set => _taskForWoman = value; }


    public bool TaskForHatman { get => _taskForHatman; set => _taskForHatman = value; }
    public bool TaskForHatmanJumpIntoWell { get => _taskForHatmanJumpIntoWell; set => _taskForHatmanJumpIntoWell = value; }

    public bool TaskForOldman { get => _taskForOldman; set => _taskForOldman = value; }
    public bool TaskForOldmanGetStaff { get => _taskForOldmanGetStaff; set => _taskForOldmanGetStaff = value; }

    public bool TaskForBearded { get => _taskForBearded; set => _taskForBearded = value; }
    public bool TaskForBeardedFillWagon { get => _taskForBeardedFillWagon; set => _taskForBeardedFillWagon = value; }
}
