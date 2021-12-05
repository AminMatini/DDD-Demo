using DDD.Logic;
using FluentAssertions;
using Xunit;
using static DDD.Logic.Money;

namespace DDD.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empties_money_in_transactions()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(OneDollar);
            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }

        [Fact]
        public void Inserted_money_goes_to_money_In_tranaction()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(OneCent);
            snackMachine.InsertMoney(OneDollar);

            snackMachine.MoneyInTransaction.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_then_one_coin_at_a_time()
        {
            var snackMachine = new SnackMachine();

            var tweCent = OneCent + OneCent;
            Action action = () => snackMachine.InsertMoney(tweCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Money_in_tranaction_goes_to_money_inside()
        {
            var snackMachine = new SnackMachine();

            snackMachine.InsertMoney(OneDollar);
            snackMachine.InsertMoney(OneDollar);
            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Amount.Should().Be(2m);

        }
    }
}
