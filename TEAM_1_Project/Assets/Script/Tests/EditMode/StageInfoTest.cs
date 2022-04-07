using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine.TestTools;
namespace Script.Test
{
    public class StageInfoTest
    {
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest1()
        {
            var list = StageInfo.getStageInfo();
            yield return null;
            Assert.AreNotEqual(list,null);
        }
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest2()
        {
            var list = StageInfo.getStageInfo();
            yield return null;
            Assert.AreEqual(true,list[1, 1].Contains("OneMonkey"));
        }
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest3()
        {
            var list = StageInfo.getStageInfo();
            yield return null;
            Assert.AreEqual(true,list[1, 2].Contains("OneMonkey"));
            Assert.AreEqual(true,list[1, 2].Contains("TwoMonkey"));
        }
    }
}