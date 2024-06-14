using PersonalRecord.Domain.Models;

namespace PersonalRecord.App
{
    public partial class App : Application
    {
        public App(PreparationDatabase preparationDatabase)
        {
            InitializeComponent();

            Task.Run(async () => 
            {
                await preparationDatabase.PreparatePopulation();
            });


            MainPage = new AppShell();
        }
    }
}
