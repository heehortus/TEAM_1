using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Script.Tests.PlayMode
{
    public class PlayerTest
    {
        [UnityTest]
        public IEnumerator UserPlayerTest1()
        {
            GameObject player = new GameObject();
            player.AddComponent<UserPlayer>();
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator EnemyPlayerTest1()
        {
            GameObject player = new GameObject();
            player.AddComponent<EnemyPlayer>();
            yield return null;
        }
        [UnityTest]
        public IEnumerator EnemyPlayerTest2()
        {
            GameObject player = new GameObject();
            player.AddComponent<EnemyPlayer>();
            yield return null;
        }
    }
}