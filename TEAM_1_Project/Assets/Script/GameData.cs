using UnityEditorInternal;

public class GameData
{
    private static GameData instance = null;

    public GameData()
    {
        possibleStage = new bool[4,4];
        selectStage = (0, 0);
        possibleStage[1,1] = true;
        possibleStage[3,1] = true;
    }
    public static GameData GetInstance()
    {
        if (instance == null)
        {
            instance = new GameData();
        }
        return instance;
    }
    
    public (int ,int) selectStage { get; set; }
    
    public bool[,] possibleStage { get; set; }
}