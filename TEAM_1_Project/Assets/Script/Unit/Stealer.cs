using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    public void SetUp()
    {   
        this.x = 0;
        this.y = 0;
        this.level = 0;
    }
    void stealer()
    {
        int stealCount;
        switch (level)
        {
            // ���ϰ��� ���� raycast�� ���� ���� Ÿ���� ���絵 �ǰ�, ������ ���缭 ���� ���� �տ� �����ִ��� �Ǻ��ϸ�
            // ���ڴٰ� �����߽��ϴ�.
            case 1:
                coast = 3;
                stealCount = 1;
                break;
            case 2:
                coast = 5;
                stealCount = 3;
                break;
            case 3:
                coast = 7;
                stealCount = 5;
                break;
        }

    }
}
