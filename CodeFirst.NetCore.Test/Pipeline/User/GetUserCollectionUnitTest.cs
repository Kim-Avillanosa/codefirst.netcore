using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeFirst.NetCore.Test
{
    public class GetUserCollectionUnitTest : UnitTestBase
    {
        /// <summary>
        /// Indicates that the count should be equivalent with the seed data 
        /// </summary>
        [Fact]
        public void Valid_User_GetCollection_ShouldReturn_CorrectCount()
        {
            ///Arrange
            var expected_item_count = 3;

            var handler = new GetUserCollectionHandler(userRepository);

            var request = new GetUserCollectionQuery();

            ///Act
            var evaluation = handler.Handle(request, CancellationToken.None);

            ///Assert
            Assert.Equal(expected_item_count, evaluation.Result.Count());
        }


        /// <summary>
        /// Indicates that the count should not be equivalent with the seed data 
        /// </summary>
        [Fact]
        public void Invalid_User_GetCollection_ShouldReturn_WrongCount()
        {
            ///Arrange
            var expected_item_count = 0;

            var handler = new GetUserCollectionHandler(userRepository);

            var request = new GetUserCollectionQuery();

            ///Act
            var evaluation = handler.Handle(request, CancellationToken.None);

            ///Assert
            Assert.NotEqual(expected_item_count, evaluation.Result.Count());
        }
    }
}
