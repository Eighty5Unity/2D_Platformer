public class GameTask
{
    //Woman
    private bool _taskForWoman;
    public bool TaskForWoman { get => _taskForWoman; set => _taskForWoman = value; }
    //Hatman
    private bool _taskForHatman;
    private bool _taskForHatmanJumpIntoWell;
    private bool _taskForHatmanGetRing;
    private bool _taskForHatmanGetFlowers;
    public bool TaskForHatman { get => _taskForHatman; set => _taskForHatman = value; }
    public bool TaskForHatmanJumpIntoWell { get => _taskForHatmanJumpIntoWell; set => _taskForHatmanJumpIntoWell = value; }
    public bool TaskForHatmanGetRing { get => _taskForHatmanGetRing; set => _taskForHatmanGetRing = value; }
    public bool TaskForHatmanGetFlowers { get => _taskForHatmanGetFlowers; set => _taskForHatmanGetFlowers = value; }
    //Oldman
    private bool _taskForOldman;
    private bool _taskForOldmanGetStaff;
    public bool TaskForOldman { get => _taskForOldman; set => _taskForOldman = value; }
    public bool TaskForOldmanGetStaff { get => _taskForOldmanGetStaff; set => _taskForOldmanGetStaff = value; }
    //Bearded
    private bool _taskForBearded;
    private bool _taskForBeardedFillWagon;
    public bool TaskForBearded { get => _taskForBearded; set => _taskForBearded = value; }
    public bool TaskForBeardedFillWagon { get => _taskForBeardedFillWagon; set => _taskForBeardedFillWagon = value; }
}
