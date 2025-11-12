using System.Collections.Generic;

[System.Serializable]
public class PlayerSave
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public int experience;

    public int rating;
    public int money;
    public List<string> bought_machines;
    public int currentDay; 

}