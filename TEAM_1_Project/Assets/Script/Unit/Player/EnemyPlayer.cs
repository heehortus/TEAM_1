using System;
using System.Collections.Generic;

public class EnemyPlayer : Player
{
    public List<string> monkeyList;
    public EnemyAI enemyAI;
    private void Awake()
    {
        base.Awake();
        enemyAI = new EnemyAI(this);
        _currResource = Int32.MaxValue;
    }
    
}