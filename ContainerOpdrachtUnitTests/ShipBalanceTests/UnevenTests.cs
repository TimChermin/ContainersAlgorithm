using System;
using System.Collections.Generic;
using Xunit;
using ContainerOpdrachtVersion3;

namespace ShipBalanceTests
{
    public class UnevenTests
    {
        [Fact]
        public void Should_ReturnFalse_When_TheWidthIsAnUnEvenNumber()
        {
            //Arrange
            ShipBalanceLogic shipBalanceLogic = new ShipBalanceLogic(5, 40);

            //Act
            bool resultEven = shipBalanceLogic.EvenMiddle(3);

            //Assert
            Assert.False(resultEven);
        }

        [Fact]
        public void Should_ReturnFalse_WhenAddingToTheRightWontKeepBalanceWithWeightRightAndUneven()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(5, 400);
            balanceLogic.WeightRight += 30;
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(5, container, containers);

            //Assert
            Assert.False(keepsBalance);
        }

        [Fact]
        public void Should_ReturnTrue_WhenAddingToTheLeftWillKeepBalanceWithUneven()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(5, 400);
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(1, container, containers);

            //Assert
            Assert.True(keepsBalance);
        }
        
        [Fact]
        public void Should_ReturnTrue_WhenAddingToTheRightWillKeepBalanceWithUneven()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(5, 400);
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(5, container, containers);

            //Assert
            Assert.True(keepsBalance);
        }

        [Fact]
        public void Should_ReturnFalse_WhenAddingToTheLeftWontKeepBalanceWithWeightLeftAndUneven()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(5, 400);
            balanceLogic.WeightLeft += 30;
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(1, container, containers);

            //Assert
            Assert.False(keepsBalance);
        }
    }
}
