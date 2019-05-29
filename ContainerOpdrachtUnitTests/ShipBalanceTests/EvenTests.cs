using System;
using System.Collections.Generic;
using Xunit;
using ContainerOpdrachtVersion3;

namespace UnitTests.ShipBalance
{
    public class EvenTests
    {
        [Fact]
        public void Should_ReturnTrue_When_TheWidthIsAnEvenNumber()
        {
            //Arrange
            ShipBalanceLogic shipBalanceLogic = new ShipBalanceLogic(5, 40);

            //Act
            bool resultEven = shipBalanceLogic.EvenMiddle(2);

            //Assert
            Assert.True(resultEven);
        }

        [Fact]
        public void Should_AddTheWeightToTheLeft_When_AddingToTheLeft()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            balanceLogic.Middle = 3;

            //Act
            balanceLogic.AddContainerWeight(new Container(20, false, false), 1);

            //Assert
            Assert.True(balanceLogic.WeightLeft == 20);
        }


        [Fact]
        public void Should_AddTheWeightToTheRight_When_AddingToTheRight()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            balanceLogic.Middle = 3;

            //Act
            balanceLogic.AddContainerWeight(new Container(20, false, false), 6);

            //Assert
            Assert.True(balanceLogic.WeightRight == 20);
        }

        [Fact]
        public void Should_AddTheWeightToTheMiddle_When_AddingToTheMiddle()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            balanceLogic.Middle = 3;

            //Act
            balanceLogic.AddContainerWeight(new Container(20, false, false), 3);

            //Assert
            Assert.True(balanceLogic.WeightMiddle == 20);
        }



        [Fact]
        public void Should_ReturnTrue_WhenAddingToTheLeftWillKeepBalance()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 400);
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(1, container, containers);

            //Assert
            Assert.True(keepsBalance);
        }



        [Fact]
        public void Should_ReturnTrue_WhenAddingToTheRightWillKeepBalance()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 400);
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(6, container, containers);

            //Assert
            Assert.True(keepsBalance);
        }

        [Fact]
        public void Should_ReturnFalse_WhenAddingToTheLeftWontKeepBalanceWithWeightLeft()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 400);
            balanceLogic.WeightLeft += 30;
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(2, container, containers);

            //Assert
            Assert.False(keepsBalance);
        }


        [Fact]
        public void Should_ReturnFalse_WhenAddingToTheRightWontKeepBalanceWithWeightRight()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 400);
            balanceLogic.WeightRight += 30;
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillStayBalanced(6, container, containers);

            //Assert
            Assert.False(keepsBalance);
        }
    }
}
