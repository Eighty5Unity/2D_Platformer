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
}