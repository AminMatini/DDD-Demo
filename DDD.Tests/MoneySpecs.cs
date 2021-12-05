using DDD.Logic;
using FluentAssertions;
using System;
using Xunit;

namespace DDD.Tests
{

    public class MoneySpecs
    {
        [Fact]
        public void SumOfTwoMoneyProducesCorrectResult()
        {
            // arrange 

            Money money_1 = new Money(1, 2, 3, 4, 5, 6);
            Money money_2 = new Money(1, 2, 3, 4, 5, 6);

            // act

            Money sum = money_1 + money_2;

            // assert

            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TenCentCount.Should().Be(12);
        }

        [Fact] 
        public void TwoMoneyInstancesAreEqualIfContainTheSomeMoneyAmount()
        {
            // arrange 

            Money money_1 = new Money(1, 2, 3, 4, 5, 6);
            Money money_2 = new Money(1, 2, 3, 4, 5, 6);

            // assert

            money_1.Should().Be(money_2);
            money_1.GetHashCode().Should().Be(money_2.GetHashCode());
        }

        [Fact]
        public void TwoMoneyInstancesAreNotEqualIfContainTheSomeMoneyAmount()
        {
            // arrange 

            Money dollar = new Money(0, 0, 0, 1, 0, 0);
            Money hundredCent = new Money(100, 0, 0, 0, 0, 0);

            // assert

            dollar.Should().NotBe(hundredCent);
            dollar.GetHashCode().Should().NotBe(hundredCent.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 0, -3)]
        [InlineData(0, 0, -2, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, -9, 0)]
        [InlineData(0, -6, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        public void CannotCreateMoneyWithNegativeValue(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount
            )
        {
            Action action = () =>
            {
                new Money(oneCentCount, tenCentCount, quarterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);
            };

            action.Should().Throw<InvalidOperationException>();

        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 0, 0, 0.01)]
        [InlineData(1, 2, 0, 0, 0, 0, 0.21)]
        [InlineData(1, 2, 3, 0, 0, 0, 0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        public void AmountIsCalculateCorrectly(
            int oneCentCount,
            int tenCentCount,
            int quarterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount,
            decimal expectedAmount
            )
        {
            Money money = new Money(
                oneCentCount,
                tenCentCount,
                quarterCount,
                oneDollarCount,
                fiveDollarCount,
                twentyDollarCount);

            money.Amount.Should().Be(expectedAmount);
        }

        [Fact]
        public void subtraction_of_two_moneys_produces_correct_value()
        {
            Money money_1 = new Money(10, 10, 10, 10, 10, 10);
            Money money_2 = new Money(1, 2, 3, 4, 5, 6);

            Money result = money_1 - money_2;

             result.OneCentCount.Should().Be(9);
             result.TenCentCount.Should().Be(8);
             result.QuarterCount.Should().Be(7);
             result.OneDollarCount.Should().Be(6);
             result.FiveDollarCount.Should().Be(5);
             result.TwentyDollarCount.Should().Be(4);
        }

        [Fact]
        public void connot_subtract_more_then_exists()
        {
            Money money_1 = new Money(0, 1,0, 0, 0, 0);
            Money money_2 = new Money(1, 0, 0, 0, 0, 0);

            Action action = () =>
            {
                Money money = money_1 - money_2;
            };

            action.Should().Throw<InvalidOperationException>();
        }

    }
}
