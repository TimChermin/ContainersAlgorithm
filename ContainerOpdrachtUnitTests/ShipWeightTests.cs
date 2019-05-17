using System;
using System.Collections.Generic;
using Xunit;
using ContainerOpdrachtVersion3;

namespace UnitTests
{
    public class ShipWeightTests
    {
        [Fact]
        public void Should_CheckContainerWeightForUnEvenAndEvenMiddle_When_AddingAContainer()
        {
            //Arrange
            ShipBalanceLogic shipBalanceLogic = new ShipBalanceLogic(5, 40);

            //Act
            bool resultNotEven = shipBalanceLogic.EvenMiddle(1);
            bool resultEven = shipBalanceLogic.EvenMiddle(2);

            //Assert
            Assert.False(resultNotEven);
            Assert.True(resultEven);
        }

        [Fact]
        public void Should_AddTheContainerWeightToTheShip_When_AddingContainerWeight()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            balanceLogic.Middle = 3;

            //Act
            balanceLogic.AddContainerWeight(new Container(20, false, false), 1);
            balanceLogic.AddContainerWeight(new Container(20, false, false), 3);
            balanceLogic.AddContainerWeight(new Container(20, false, false), 6);

            //Assert
            Assert.True(balanceLogic.Weight == 60);
            Assert.True(balanceLogic.WeightLeft == 20);
            Assert.True(balanceLogic.WeightRight == 20);
        }


        [Fact]
        public void Should_ReturnContainerCound_When_CheckingIfTheShipIsEmpty()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 40);
            List<Container> containers = new List<Container>();
            List<Container> containersEmpty = new List<Container>();
            containers.Add(new Container(5, true, true));
            containers.Add(new Container(5, true, true));

            //Act
            int count = balanceLogic.IsTheShipEmpty(containers);
            int emptyCount = balanceLogic.IsTheShipEmpty(containersEmpty);

            //Assert
            Assert.True(count == 2);
            Assert.True(emptyCount == 0);
        }

        [Fact]
        public void Should_ReturnTrue_WhenCheckingIfTheRightLocationWillKeepTheBalanceOfTheShip()
        {
            //Arrange
            ShipBalanceLogic balanceLogic = new ShipBalanceLogic(6, 400);
            ShipBalanceLogic balanceLogic2 = new ShipBalanceLogic(6, 400);
            balanceLogic2.WeightLeft += 30;
            List<Container> containers = new List<Container>();
            Container container = new Container(20, false, false);
            containers.Add(container);

            //Act
            bool keepsBalance = balanceLogic.WillThisLocationKeepTheBalanceOfTheShip(1, container, containers);
            bool keepsBalance2 = balanceLogic.WillThisLocationKeepTheBalanceOfTheShip(6, container, containers);

            bool keepsBalance3 = balanceLogic2.WillThisLocationKeepTheBalanceOfTheShip(6, container, containers);
            bool DoesntKeepBalance = balanceLogic2.WillThisLocationKeepTheBalanceOfTheShip(2, container, containers);
            bool DoesntkeepBalance2 = balanceLogic2.WillThisLocationKeepTheBalanceOfTheShip(1, container, containers);

            //Assert
            Assert.True(keepsBalance);
            Assert.True(keepsBalance2);
            Assert.True(keepsBalance3);
            Assert.False(DoesntKeepBalance);
            Assert.False(DoesntkeepBalance2);
        }

        [Fact]
        public void Should_ReturnTrue_WhenAddingAContainerWontGoOverMaxWeightOnTopOfOne()
        {
            //Arrange
            ContainerColumn column = new ContainerColumn(5, 5, 6);
            ContainerColumn column2 = new ContainerColumn(5, 5, 6);
            Container container = new Container(30, false, false);
            column.containerStack.Add(container);
            column.containerStack.Add(container);
            column.containerStack.Add(container);
            column.containerStack.Add(container);

            //Act
            column.CountStack();
            bool cantAdd = column.AddingContainerWouldNotGoOverMaxWeight(container);
            bool canAdd = column2.AddingContainerWouldNotGoOverMaxWeight(container);

            //Assert
            Assert.True(cantAdd);
            Assert.True(canAdd);
        }


    }
}
