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
            Assert.AreEqual(list[1, 1].First(),"OneMonkey");
        }
    }
}