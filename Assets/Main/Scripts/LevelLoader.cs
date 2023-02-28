using UnityEngine.SceneManagement;

public class LevelLoader
{
    public LevelLoader(int number)
    {
        SceneManager.LoadScene(number);
    }

    public LevelLoader(string name)
    {
        SceneManager.LoadScene(name);
    }
}
