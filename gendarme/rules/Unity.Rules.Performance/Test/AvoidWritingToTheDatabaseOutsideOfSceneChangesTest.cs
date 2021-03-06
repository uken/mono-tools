using NUnit.Framework;

using Test.Rules.Definitions;
using Test.Rules.Fixtures;

using Unity.Rules.Performance;
using UnityEngine;

namespace Tests.Unity.Rules.Performance
{
    [TestFixture]
    public class AvoidWritingToTheDatabaseOutsideOfSceneChangesTest : MethodRuleTestFixture<AvoidWritingToTheDatabaseOutsideOfSceneChangesRule>
    {

        [Test]
        public void QueryDatabaseFailTest()
        {
            AssertRuleFailure<LQDBSelectAll>( "Update" );
            AssertRuleFailure<LQDBSelectAll>( "FixedUpdate" );
            AssertRuleFailure<LQDBSelectAll>( "LateUpdate" );
        }
    }

    public class LQDBSelectAll : MonoBehaviour
    {
        void Update()
        {
            LQDB.SelectAll();
        }

        void FixedUpdate()
        {
            LQDB.SelectAll();
        }

        void LateUpdate()
        {
            LQDB.SelectAll();
        }
    }

    public class LQDB {
        public static void SelectAll(){
            return;
        }
    }
}
