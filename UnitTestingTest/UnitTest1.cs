using System;
using Xunit;
using static Unit_Testing.Program;

namespace UnitTestingTest
{
    public class UnitTest1
    {

        [Fact]
        public void CanDepositPositive()
        {
            Assert.True(DepositMoney(1000m));
        }

        [Fact]
        public void BalanceUpdatedAfterDeposit()
        {
            balance = 0m;
            DepositMoney(500m);
            Assert.Equal(500, balance);
        }


        [Fact]
        public void CantDepositNegative()
        {
            Assert.False(DepositMoney(-1000m));
        }

        [Fact]
        public void CanWithdrawPositive()
        {
            balance = 1000;
            Assert.True(WithdrawMoney(1000m));
        }

        [Fact]
        public void BalanceUpdatedAfterWithdrawl()
        {
            balance = 500m;
            WithdrawMoney(500m);
            Assert.Equal(0, balance);
        }


        [Fact]
        public void CantWithdrawNegative()
        {
            Assert.False(WithdrawMoney(-1000m));
        }

        [Fact]
        public void CanProcessMoneyAsString()
        {
            Assert.Equal(100m, ProcessMoney("100"));
        }

        [Fact]
        public void CanProcessChoiceAsString()
        {
            Assert.Equal(2, ProcessChoice("2"));
        }

        

        [InlineData(200)]
        [InlineData(101)]
        [Theory]
        public void CantWithdrawWithInsufficientBalance(decimal money)
        {
            balance = 100;
            WithdrawMoney(money);
            Assert.Equal(100, balance);
        }

        [InlineData("2")]
        [InlineData("1")]
        [Theory]
        public void ProcessChoiceNoExceptionThrown(string choice)
        {
            ProcessChoice(choice);
            Assert.True(true);
        }

        [InlineData("2z")]
        [InlineData("OneHundred")]
        [InlineData("5")]
        [InlineData("0")]
        [Theory]
        public void ProcessChoiceExceptionThrown(string choice)
        {
            try
            {
                ProcessChoice(choice);
            }
            catch
            {
                Assert.True(true);
            }

        }


        [InlineData("2")]
        [InlineData("1000.0")]
        [Theory]
        public void ParseMoneyNoExceptionThrown(string money)
        {
            ProcessMoney(money);
            Assert.True(true);
        }

        [InlineData("$100")]
        [InlineData("-100")]
        [Theory]
        public void ParseMoneyExceptionThrown(string money)
        {
            try
            {
                ProcessMoney(money);
            }
            catch
            {
                Assert.True(true);
            }

        }
    }
}
