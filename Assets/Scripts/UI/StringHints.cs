public static class StringHints
{
    public static string KeyE = "Press E";
    public static string EnterHouse = "to enter the house";
    public static string ExitHouse = "to exit the house";

    public static string CharacterTask(CharactersEnum character)
    {
        string task;
        switch (character)
        {
            case CharactersEnum.Woman:
                task = "Task for woman";
                break;
            case CharactersEnum.Oldman:
                task = "Task for oldman";
                break;
            case CharactersEnum.Bearded:
                task = "Task for bearded";
                break;
            case CharactersEnum.Hatman:
                task = "Task for hatman";
                break;
            default:
                task = "";
                break;
        }
        return task;
    }
}
