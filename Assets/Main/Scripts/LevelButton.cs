using UnityEngine;

public class LevelButton : UIButton
{
    [SerializeField] private int LvlNumber;

    public override void Click()
    {
        new LevelLoader(LvlNumber);
    }
}
