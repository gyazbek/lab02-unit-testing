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
            Assert.Equal(true, DepositMoney(1000m));
        }

        [Fact]
        public void BalanceUpdatedAfterDeposit()
        {
            balance = 0m;
            DepositMoney(500m);
            Assert.Equal(balance,500);
        }


        [Fact]
        public void CantDepositNegative()
        {
            Assert.Equal(false, DepositMoney(-1000m));
        }

        [Fact]
        public void CanWithdrawPositive()
        {
            Assert.Equal(true, WithdrawMoney(1000m));
        }

        [Fact]
        public void BalanceUpdatedAfterWithdrawl()
        {
            balance = 500m;
            WithdrawMoney(500m);
            Assert.Equal(balance, 0);
        }


        [Fact]
        public void CantWithdrawNegative()
        {
            Assert.Equal(false, WithdrawMoney(-1000m));
        }
    }
}
