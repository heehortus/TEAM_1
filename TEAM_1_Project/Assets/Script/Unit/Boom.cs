using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Unit
{
    public void SetUp()
    {
        this.x = 0;
        this.y = 0;
        this.level = 0;
    }
    void boom()
    {
        int attackPower;
        switch (level)
        {
            // ��ź�� ���� ��Ȯ�� ���� �ƴ�����, ������ ��ź�� ��� �ڱ� �������� ���� �׷� �ý����̶��
            // layer�� ����Ͽ� ��� ������ ���� �������� �ڵ带 ¥�� ��� �����غý��ϴ�
            case 1:
                coast = 3;
                attackPower = 3;
                break;
            case 2:
                coast = 5;
                attackPower = 5;
                break;
            case 3:
                coast = 7;
                attackPower = 7;
                break;
        }
    }


}
