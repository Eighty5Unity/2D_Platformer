public static class StringHints
{
    public static string KeyE = "Press E";
    public static string EnterHouse = "to enter the house";
    public static string ExitHouse = "to exit the house";
    public static string TaskDone = "all tasks completed";
    public static string HiWoman = "Hi woman!";
    public static string HiOldman = "Hi oldman!";
    public static string HiBearded = "Hi bearded!";
    public static string HiHatman = "Hi hatman!";

    public static string CharacterTask(CharactersEnum character)
    {
        string task;
        switch (character)
        {
            case CharactersEnum.Woman:
                task = "Life is Beautiful";
                break;
            case CharactersEnum.Oldman:
                task = "I lost my staff, the last time I saw it was near the well";
                break;
            case CharactersEnum.Bearded:
                task = "I need to fill the wagon with barrels";
                break;
            case CharactersEnum.Hatman:
                task = "I need flowers and a ring, I want to propose to my girlfriend";
                break;
            default:
                task = "";
                break;
        }
        return task;
    }

    public static string UseWell(CharactersEnum character)
    {
        string hint;
        switch (character)
        {
            case CharactersEnum.Hatman:
                hint = KeyE + " to jump into the well";
                break;
            case CharactersEnum.Bearded:
                hint = KeyE + " to lift from the bottom";
                break;
            case CharactersEnum.Woman:
                hint = "I won't jump there!";
                break;
            case CharactersEnum.Oldman:
                hint = "I'm too old to jump there!";
                break;
            default:
                hint = "";
                break;
        }
        return hint;
    }
}
