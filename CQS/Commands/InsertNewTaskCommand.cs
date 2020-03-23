using TaskHeroes.CQSInterfaces;

namespace TaskHeroes.CQS.Commands
{
    public class InsertNewTaskCommand : ICommand
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string JobType { get; set; }
        public decimal MoneyOffer { get; set; }
        public decimal WorkPeriod { get; set; }
        public int OffererId { get; set; }

        public InsertNewTaskCommand(string title, string description, string jobType, decimal moneyOffer, decimal workPeriod, int offererId)
        {
            Title = title;
            Description = description;
            JobType = jobType;
            MoneyOffer = moneyOffer;
            WorkPeriod = workPeriod;
            OffererId = offererId;
        }
    }
}
