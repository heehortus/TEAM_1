using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    // Start is called before the first frame update
    public void SetUp()
    {
        this.x = 0;
        this.y = 0;
        this.level = 0;
    }
    void seed()
    {
        switch (level)
        {
            // �� �Ŵ������� �� ���� �޾ƿ� �� ���� ���� �� �� ���� level�� �����ϵ��� ¥�� ��� �����߽��ϴ�.
            case 1:
                coast = 3;
                break;
            case 2:
                coast = 5;
                break;
            case 3:
                coast = 7;
                break;
        }
    }
}
