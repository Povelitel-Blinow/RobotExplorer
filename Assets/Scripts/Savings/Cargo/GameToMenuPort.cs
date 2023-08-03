using UnityEngine.SceneManagement;

public static class GameToMenuPort
{
    public static void StartGame(RobotStruct robot)
    {
        DataHandler.robotStruct = robot;
        SceneManager.LoadScene(1);
    }

    public static void EndGame(CristallCollector cristallCollector)
    {
        CargoHandler.BlueCristals = cristallCollector.GetBlueCristalsAmount();
        CargoHandler.RedCristals = cristallCollector.GetRedCristalsAmount();
        SceneManager.LoadScene(0);
    }
}
