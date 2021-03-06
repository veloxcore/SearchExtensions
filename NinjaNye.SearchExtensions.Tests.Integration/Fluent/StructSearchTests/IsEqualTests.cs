using System;
using System.Linq;
using NUnit.Framework;

namespace NinjaNye.SearchExtensions.Tests.Integration.Fluent.StructSearchTests
{
    [TestFixture]
    internal class IsEqualTests : IDisposable
    {
        private readonly TestContext _context = new TestContext();

        [Test]
        public void IsEqual_CallWithValue_DoesNotThrowAnException()
        {
            //Arrange
            
            //Act

            //Assert
            Assert.DoesNotThrow(() => this._context.TestModels.Search(x => x.IntegerOne).EqualTo(1));
        }

        [Test]
        public void IsEqual_CallWithValue_DoesNotReturnNull()
        {
            //Arrange
            
            //Act 
            var result = this._context.TestModels.Search(x => x.IntegerOne).EqualTo(50);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void IsEqual_CallWithValue_AllRecordsHaveEqualPropertyValues()
        {
            //Arrange
            
            //Act
            var result = this._context.TestModels.Search(x => x.IntegerOne).EqualTo(101);

            //Assert
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.All(x => x.IntegerOne == 101));
        }

        [Test]
        public void IsEqual_SearchMultipleProperties_RecordsFromSecondPropertyMatchRequest()
        {
            //Arrange
            
            //Act
            var result = this._context.TestModels.Search(x => x.IntegerOne, x => x.IntegerThree)
                                                .EqualTo(3);

            //Assert
            Assert.IsTrue(result.All(x => x.IntegerOne == 3 || x.IntegerThree == 3));
        }

        [Test]
        public void IsEqual_SearchMultipleAgainstMultipleValues_RecordsMatchingBothValuesReturned()
        {
            //Arrange
            
            //Act
            var result = this._context.TestModels.Search(x => x.IntegerOne, x => x.IntegerThree)
                                                .EqualTo(3, 101);

            //Assert
            Assert.IsTrue(result.All(x => x.IntegerOne == 3 || x.IntegerThree == 3 
                                       || x.IntegerOne == 101 || x.IntegerThree == 101));
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}