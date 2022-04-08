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
            var list = StageInfo.getStageUnitInfo();
            yield return null;
            Assert.AreNotEqual(list,null);
        }
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest2()
        {
            var list = StageInfo.getStageUnitInfo();
            yield return null;
            Assert.AreEqual(true,list[1, 1].Contains("OneMonkey"));
        }
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest3()
        {
            var list = StageInfo.getStageUnitInfo();
            yield return null;
            Assert.AreEqual(true,list[1, 2].Contains("OneMonkey"));
            Assert.AreEqual(true,list[1, 2].Contains("TwoMonkey"));
        }
        [UnityTest]
        public IEnumerator LoadEnemyUnitTest4()
        {
            var list = StageInfo.getStageUnitInfo(1,2);
            yield return null;
            Assert.AreEqual(true,list.Contains("OneMonkey"));
            Assert.AreEqual(true,list.Contains("TwoMonkey"));
        }

        [UnityTest]
        public IEnumerator LoadEnemyUnitTest5()
        {
            var list = StageInfo.getStageUnitInfo();
            yield return null;
            Assert.AreEqual(true,list[1,1].Contains("BoomUnit1"));
            Assert.AreEqual(true,list[3,3].Contains("BoomUnit1"));
        }
    }
}