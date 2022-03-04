using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeFirst.NetCore.Test
{
    public class GetUserByIdUnitTest : UnitTestBase
    {
        [Fact]
        public async void Valid_User_Get_ShouldReturn_EqualValue()
        {
            //arrange
            var expectedUser = new User(1, 1, "kmavillanosa@gmail.com", "kmavillanosa", "Kim", "Avillanosa", "09452873791", "google.com");
            
            var parameter = 1;

            //act
            var result = await userRepository.GetAsync(parameter);

            //assert
            Assert.Equal(expectedUser.Email, result.Email);

        }

        [Fact]
        public async void Invalid_User_Get_ShouldReturn_NotEqualValue()
        {
            //arrange
            var expectedUser = new User(1, 1, "kmavillanosa@gmail.com", "kmavillanosa", "Kim", "Avillanosa", "09452873791", "google.com");
            
            var parameter = 2;

            //act
            var result = await userRepository.GetAsync(parameter);

            //assert
            Assert.NotEqual(expectedUser.Email, result.Email);

        }


        [Fact]
        public void Invalid_User_Get_ShouldThrow_ConflictException()
        {
            //arrange
            var parameter = 22231;

            //act && assert
            Assert.Throws<ConflictException>(() => 
            {
                userRepository.GetAsync(parameter);
            });

        }
    }
}
